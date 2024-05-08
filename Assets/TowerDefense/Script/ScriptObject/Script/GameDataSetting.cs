using TowerDefense.Script.Abstract;
using TowerDefense.Script.EventCenter;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [CreateAssetMenu(fileName = "GameDataSettingSo", menuName = "TowerDefense2D/Create GameDataSO")]
    public class GameDataSetting : ScriptableObject
    {
        [SerializeField] public static int Hp;
        [SerializeField] public static int Money;
        [SerializeField] public static int Loop;
        [SerializeField] public static int Progress;
        [SerializeField] public static int MaxExperience = 400; //todo 暫時給他
        [SerializeField] public static int Experience;

        private void OnEnable()
        {
            // 在GameDataSetting啟用時訂閱事件
            MoneyEventMediator.OnEnemyDeathGetMoney += UpdateMoneyValuesOnEnemyDeathGetMoney;
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
            // 更新金錢和循環數值
            Money += bounty;
            Loop += loopIncrement;

            MoneyEventCenter.Broadcast(MoneyEventType.AddMoney, Money);
            MoneyEventCenter.Broadcast(MoneyEventType.AddLoop, Loop);
        }
        
        private void UpdateExperienceValuesOnEnemyDeathGetMoney(int experience)
        {
            // 更新經驗條
            Experience += experience;
            var experienceValue = Experience / (float)MaxExperience;
            ExperienceEventCenter.Broadcast(ExperienceEventType.UpdataExperience, experienceValue);
        }
    }
}