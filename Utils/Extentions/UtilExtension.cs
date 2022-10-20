using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public static class UtilExtension
{
  


    public static TValue TryGetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
    {
        /// <summary>
        /// 扩展字典类中的TryGetValue方法
        /// 可以直接通过给出key返回value,而不是像原方法一样返回bool值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>

        TValue value;
        dict.TryGetValue(key, out value);

        return value;
    }

    /// <summary>
    /// 扩展List类
    /// 查找字段是指定UIPanelType的UIPanel,返回UIPanel的引用
    /// </summary>
    /// <param name="list">UIPanel的List</param>
    /// <param name="type"></param>
    /// <returns></returns>
    /// 
    public static UIPanel SearchPanelForType(this List<UIPanel> list, eUIPanelType type)
    {
        foreach (var item in list)
        {
            if (item.UIPanelType == type)
                return item;
        }

        return null;
    }

    public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
    {
        T component = obj.GetComponent<T>();
        if (component == null)
        {
            return obj.AddComponent<T>();
        }

        return component;
    }

    public static void SafeSetActive(UnityEngine.Object obj, bool active) 
    {
        if (obj != null)
        {
            if (obj is GameObject)
            {
                ((GameObject)obj).SetActive(active);
            }
            else if (obj is Component)
            {
                ((GameObject)obj).gameObject.SetActive(active);
            }
        }
    }

    public static char ValidateInt(string text, int charIndex, char charToValidate)
    {
        if ((charToValidate >= '0' && charToValidate <= '9'))
        {
            return charToValidate;
        }

        return char.MinValue;
    }

    public static char ValidateFloat(string text, int charIndex, char charToValidate)
    {
        if ((charToValidate >= '0' && charToValidate <= '9') || (charIndex > 0 && charToValidate == '.'))
        {
            return charToValidate;
        }
        return char.MinValue;
    }

    public static void InputIntAndSave(TMP_InputField input, string key = nameof(Input),int defaultValue = 2)
    {
        if (PlayerPrefs.HasKey(key))
        {
            input.text = PlayerPrefs.GetInt(key).ToString();
            Debug.Log(key+ " : " + input.text);
        }
        else 
        {
            input.text = defaultValue.ToString();
        }
        
        input.onValidateInput += ValidateInt;
        input.onValueChanged.AddListener((value) =>
        {
            if (string.IsNullOrEmpty(value))
            {
                value = 1.ToString();
            }
            else if (int.Parse(value) < 1)
            {
                input.text = 1.ToString();
                value = 1.ToString();
            }
            PlayerPrefs.SetInt(key, int.Parse(value));
        });
    }

    public static void InputFloatAndSave(TMP_InputField input, string key = nameof(Input),float defaultValue = 2.8f)
    {
        if (PlayerPrefs.HasKey(key))
        {
            input.text = PlayerPrefs.GetFloat(key).ToString();
        }
        else
        {
            input.text = defaultValue.ToString();
        }

        input.onValidateInput += ValidateFloat;
        input.onValueChanged.AddListener((value) =>
        {
            if (string.IsNullOrEmpty(value))
            {
                value = 1.ToString();
            }
            else if (float.Parse(value) < 1)
            {
                input.text = 1.ToString();
                value = 1.ToString();
            }
            PlayerPrefs.SetFloat(key, float.Parse(value));
        });
    }
}
