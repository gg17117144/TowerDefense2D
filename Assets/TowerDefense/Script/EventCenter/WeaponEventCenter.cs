using System;
using System.Collections.Generic;

namespace TowerDefense.Script.EventCenter
{
    public enum WeaponEventType
    {
        UpdataWeaponData,
    }

    public class WeaponEventCenter
    {
        private static readonly Dictionary<WeaponEventType, Action<string>> WeaponEventDict =
            new Dictionary<WeaponEventType, Action<string>>();

        /// <summary>
        /// 添加事件監聽
        /// </summary>
        public static void AddListener(WeaponEventType eventType, Action<string> callback)
        {
            if (!WeaponEventDict.ContainsKey(eventType))
            {
                WeaponEventDict.Add(eventType, null);
            }

            WeaponEventDict[eventType] += callback;
        }

        /// <summary>
        /// 移除事件監聽
        /// </summary>
        public static void RemoveListener(WeaponEventType eventType, Action<string> callback)
        {
            if (!WeaponEventDict.ContainsKey(eventType))
                return;

            if (WeaponEventDict[eventType] == null)
                return;

            WeaponEventDict[eventType] -= callback;
        }

        /// <summary>
        /// 廣播
        /// </summary>
        public static void Broadcast(WeaponEventType eventType, string data)
        {
            if (!WeaponEventDict.ContainsKey(eventType))
                return;

            Action<string> callback = WeaponEventDict[eventType];

            if (callback != null)
            {
                callback(data);
            }
        }

        public static void CleanAllEvent()
        {
            WeaponEventDict.Clear();
        }
    }
}