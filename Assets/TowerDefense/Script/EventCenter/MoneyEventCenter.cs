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
        private static readonly Dictionary<MoneyEventType, Action<int>> m_EventDict =
            new Dictionary<MoneyEventType, Action<int>>();

        /// <summary>
        /// 添加事件監聽
        /// </summary>
        public static void AddListener(MoneyEventType eventType, Action<int> callback)
        {
            if (!m_EventDict.ContainsKey(eventType))
            {
                m_EventDict.Add(eventType, null);
            }

            m_EventDict[eventType] += callback;
        }

        /// <summary>
        /// 移除事件監聽
        /// </summary>
        public static void RemoveListener(MoneyEventType eventType, Action<int> callback)
        {
            if (!m_EventDict.ContainsKey(eventType))
                return;

            if (m_EventDict[eventType] == null)
                return;

            m_EventDict[eventType] -= callback;
        }

        /// <summary>
        /// 廣播
        /// </summary>
        public static void Broadcast(MoneyEventType eventType, int data)
        {
            if (!m_EventDict.ContainsKey(eventType))
                return;

            Action<int> callback = m_EventDict[eventType];

            if (callback != null)
            {
                callback(data);
            }
        }

        public static void CleanAllEvent()
        {
            m_EventDict.Clear();
        }
    }
}