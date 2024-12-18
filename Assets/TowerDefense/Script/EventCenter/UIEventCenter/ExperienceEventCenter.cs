using System;
using System.Collections.Generic;

namespace TowerDefense.Script.EventCenter.UIEventCenter
{
    public enum ExperienceEventType
    {
        UpdataExperience, LeverUp,
    }

    public class ExperienceEventCenter
    {
        private static readonly Dictionary<ExperienceEventType, Action<float>> ExperienceEventDict =
            new Dictionary<ExperienceEventType, Action<float>>();

        /// <summary>
        /// 添加事件監聽
        /// </summary>
        public static void AddListener(ExperienceEventType eventType, Action<float> callback)
        {
            if (!ExperienceEventDict.ContainsKey(eventType))
            {
                ExperienceEventDict.Add(eventType, null);
            }

            ExperienceEventDict[eventType] += callback;
        }

        /// <summary>
        /// 移除事件監聽
        /// </summary>
        public static void RemoveListener(ExperienceEventType eventType, Action<float> callback)
        {
            if (!ExperienceEventDict.ContainsKey(eventType))
                return;

            if (ExperienceEventDict[eventType] == null)
                return;

            ExperienceEventDict[eventType] -= callback;
        }

        /// <summary>
        /// 廣播
        /// </summary>
        public static void Broadcast(ExperienceEventType eventType, float data)
        {
            if (!ExperienceEventDict.ContainsKey(eventType))
                return;

            Action<float> callback = ExperienceEventDict[eventType];

            if (callback != null)
            {
                callback(data);
            }
        }

        public static void CleanAllEvent()
        {
            ExperienceEventDict.Clear();
        }
    }
}