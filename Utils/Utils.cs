using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

using UnityEngine.UIElements;

using System;
using TMPro;
using UnityEngine.Events;

public class Utils: MonoBehaviour
{
    public enum ePlaceType 
    {
        Circle = 0,
        Eclipse = 1
    }

    /// <summary>
    /// Utils.GetEnumByValue(typeof(ConfigPanel.eCameraGenerateMethod),"0")
    /// </summary>
    /// <param name="enumType"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Enum GetEnumByValue(Type enumType, string value)
    {
        return Enum.Parse(enumType, value) as Enum;
    }

    public static void InitTMPDropDownByEnum(Type e, TMP_Dropdown TMP_dpd)
    {
        TMP_dpd.options.Clear();
        TMP_Dropdown.OptionData optionData;
        for (int i = 0; i < Enum.GetNames(e).Length; i++)
        {
            optionData = new TMP_Dropdown.OptionData();
            optionData.text = Utils.GetEnumByValue(e, i.ToString()).ToString();
            optionData.image = null;
            TMP_dpd.options.Add(optionData);
        }
    }


    /// <summary>
    /// Basic value type, such as int, float, string should use PlayerPrefs.SetXXX();
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ObjectData"></param>
    public static void SaveJson(string key, object ObjectData)
    {
        string json = JsonUtility.ToJson(ObjectData);

        PlayerPrefs.SetString(key,json);
        PlayerPrefs.Save();

#if UNITY_EDITOR
        Debug.Log("[SavedData]Save Success！" + key + " : " + ObjectData);
#endif 
    }


    public static IEnumerator Delay(float time, UnityAction doAfterDelay = null)
    {
        yield return new WaitForSeconds(time);
        if (doAfterDelay != null)
        {
            doAfterDelay.Invoke();
        }
    }




    public static void PlaceObjByCircle(GameObject go , int num, float radius = 10f, float height = 2.8f) 
    {
        for (int i = 0; i < num; i++)
        {

            
            //算出物体间隔角度
            float angle = i * Mathf.PI * 2 / num;
            //利用三角函数求位置
            Vector3 pos = new Vector3(Mathf.Cos(angle), height/radius, Mathf.Sin(angle)) * radius;
      
            Instantiate(go,pos,Quaternion.identity);
      
        }
    }

    public static void PlaceObjByCircle(GameObject go, Transform lookatTransform, int num, float radius = 10f, float height = 2.8f) 
    {
        for (int i = 0; i < num; i++)
        {
            //算出物体间隔角度
            float angle = i * Mathf.PI * 2 / num;
            //利用三角函数求位置
            Vector3 pos = new Vector3(Mathf.Cos(angle), height/radius, Mathf.Sin(angle)) * radius;
            //如果此go是相机
            if (go.GetComponent<Camera>())
            {
                var Obj = Instantiate(go, pos, Quaternion.identity);
                Obj.name = "Camera" + i.ToString();
                Obj.transform.LookAt(lookatTransform.position);
            }
        }
    }

    /// <summary>
    /// Genrate GameObjects by Ellipse
    /// </summary>
    /// <param name="go"></param>
    /// <param name="num"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static void PlaceObjByEllipse(GameObject go, Transform lookatTransform, int num, float a = 3, float b = 4,float height = 2.8f)
    {
        for (int i = 0; i < num; i++)
        {
            float step_angle = 360 / num; 
            float angle = (i*step_angle/180)*Mathf.PI;
            float xx = a*Mathf.Cos(angle);
            float yy = b*Mathf.Sin(angle);

            Vector3 pos = new Vector3(xx, height,yy);

            //如果此go是相机
            if (go.GetComponent<Camera>())
            {
                var Obj = Instantiate(go, pos, Quaternion.identity);
                Obj.name = "Camera" + i.ToString();
                go.GetComponent<Camera>().targetDisplay = i;
                Obj.transform.LookAt(lookatTransform.position);
            }

        }
    }

}
