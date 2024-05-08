using System;
using System.Collections.Generic;

namespace TowerDefense.Script.EventCenter
{
    public enum MoneyEventType
    {
        AddMoney,
        AddLoop,
    }

    public class MoneyEventCenter
    {
        private static readonly Dictionary<MoneyEventType, Action<int>> MoneyEventDict =
            new Dictionary<MoneyEventType, Action<int>>();

        /// <summary>
        /// 添加事件監聽
        /// </summary>
        public static void AddListener(MoneyEventType eventType, Action<int> callback)
        {
            if (!MoneyEventDict.ContainsKey(eventType))
            {
                MoneyEventDict.Add(eventType, null);
            }

            MoneyEventDict[eventType] += callback;
        }

        /// <summary>
        /// 移除事件監聽
        /// </summary>
        public static void RemoveListener(MoneyEventType eventType, Action<int> callback)
        {
            if (!MoneyEventDict.ContainsKey(eventType))
                return;

            if (MoneyEventDict[eventType] == null)
                return;

            MoneyEventDict[eventType] -= callback;
        }

        /// <summary>
        /// 廣播
        /// </summary>
        public static void Broadcast(MoneyEventType eventType, int data)
        {
            if (!MoneyEventDict.ContainsKey(eventType))
                return;

            Action<int> callback = MoneyEventDict[eventType];

            if (callback != null)
            {
                callback(data);
            }
        }

        public static void CleanAllEvent()
        {
            MoneyEventDict.Clear();
        }
    }
}