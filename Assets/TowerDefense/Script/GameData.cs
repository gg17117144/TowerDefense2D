using System;
using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerDefense.Script
{
    public class GameData : MonoBehaviour
    {
        public static GameData instance;
        [SerializeField] private GameDataSetting gameData;
        [SerializeField] public GameDataSetting gamingData;

        private void Awake()
        {
            instance = this;
            gamingData = gameData;
        }
        
        public void ConsumeLoot(int value) 
        {
            // 在這裡實現扭蛋的邏輯
            gamingData.loot -= value;
        }
        
        public void UpdataMaxExperience(int value)
        {
            gamingData.maxExperience = value;
        }

        [Button]
        public void ResetExperience()
        {
            gamingData.experience = 0;
        }
        
        [Button]
        public void SavePlayerpref()
        {
            PlayerPrefs.SetInt("hp",gamingData.hp);
            PlayerPrefs.SetInt("money",gamingData.money);
            PlayerPrefs.SetInt("loot",gamingData.loot);
            PlayerPrefs.SetInt("progress",gamingData.progress);
            PlayerPrefs.SetInt("maxExperience",gamingData.maxExperience);
            PlayerPrefs.SetInt("experience",gamingData.experience);
            
            PlayerPrefs.SetString("experience",gamingData.bagWeaponData.ToString());
            Debug.Log($"gamingData.bagWeaponData.ToString():{gamingData.bagWeaponData.ToString()}");
        }

        [Button]
        void ClearPlayerpref()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}