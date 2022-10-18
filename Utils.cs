using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UIElements;

public class Utils: MonoBehaviour
{
    public enum ePlaceType 
    {
        Circle = 0,
        Eclipse = 1
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
