using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;

namespace TowerDefense.Script
{
    public class GameData : MonoBehaviour
    {
        public static GameData Instance;
        [SerializeField] public GameDataSetting gamingData;
        
        void Start()
        {
            Instance = this;
        }
        
        public void ConsumeLoot(int value) {
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
    }
}