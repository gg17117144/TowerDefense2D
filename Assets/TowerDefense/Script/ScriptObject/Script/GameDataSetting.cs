using TowerDefense.Script.EventCenter;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerDefense.Script.ScriptObject.Script
{
    [CreateAssetMenu(fileName = "GameDataSettingSo", menuName = "TowerDefense2D/Create GameDataSO")]
    public class GameDataSetting : ScriptableObject
    {
        [SerializeField] public int hp;
        [SerializeField] public int money;
        [SerializeField] public int loot;
        [SerializeField] public int progress;
        [SerializeField] public int maxExperience = 400; //todo 暫時給他
        [SerializeField] public int experience;

        private void OnEnable()
        {
            // 在GameDataSetting啟用時訂閱事件
            MoneyEventMediator.OnEnemyDeathGetMoney += UpdateMoneyValuesOnEnemyDeathGetMoney;
            MoneyEventMediator.OnDoGachaConsumeLoot += UpdateMoneyValuesOnDoGachaConsumeLoot;
            ExperienceEventMediator.OnEnemyDeathGetExperience += UpdateExperienceValuesOnEnemyDeathGetMoney;
        }

        private void OnDisable()
        {
            // 在GameDataSetting禁用時取消訂閱事件，以避免內存洩漏
            MoneyEventMediator.OnEnemyDeathGetMoney -= UpdateMoneyValuesOnEnemyDeathGetMoney;
            ExperienceEventMediator.OnEnemyDeathGetExperience -= UpdateExperienceValuesOnEnemyDeathGetMoney;
        }

        private void UpdateMoneyValuesOnEnemyDeathGetMoney(int bounty, int loopIncrement)
        {
            // 更新金錢和搶劫數值
            money += bounty;
            loot += loopIncrement;

            MoneyEventCenter.Broadcast(MoneyEventType.AddMoney, money);
            MoneyEventCenter.Broadcast(MoneyEventType.AddLoot, loot);
        }
        
        private void UpdateMoneyValuesOnDoGachaConsumeLoot(int lootIncrement)
        {
            // 更新搶茄數值
            loot += lootIncrement;
            
            MoneyEventCenter.Broadcast(MoneyEventType.AddLoot, loot);
        }

        private void UpdateExperienceValuesOnEnemyDeathGetMoney(int experience)
        {
            // 更新經驗條
            this.experience += experience;
            var experienceValue = this.experience / (float)maxExperience;
            ExperienceEventCenter.Broadcast(ExperienceEventType.UpdataExperience, experienceValue);
        }
    }
}