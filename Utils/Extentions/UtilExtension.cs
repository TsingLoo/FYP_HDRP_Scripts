using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
