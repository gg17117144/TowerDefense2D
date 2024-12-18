using System.Collections.Generic;
using NaughtyAttributes;
using TowerDefense.Script.EventCenter.EventMediator;
using TowerDefense.Script.EventCenter.UIEventCenter;
using UnityEngine;
using ExperienceEventMediator = TowerDefense.Script.EventCenter.EventMediator.ExperienceEventMediator;
using MoneyEventMediator = TowerDefense.Script.EventCenter.EventMediator.MoneyEventMediator;

namespace TowerDefense.Script.ScriptObject.Script
{
    [CreateAssetMenu(fileName = "GameDataSettingSo", menuName = "TowerDefense2D/Create GameDataSO")]
    public class GameDataSetting : ScriptableObject
    {
        [BoxGroup("數值")] [SerializeField] public int hp;

        // [BoxGroup("數值")] [SerializeField] public List<WeaponDamageValue> weaponDamageValue;
        [BoxGroup("數值")] [SerializeField] public int money;
        [BoxGroup("數值")] [SerializeField] public int loot;
        [BoxGroup("數值")] [SerializeField] public int progress;
        [BoxGroup("數值")] [SerializeField] public int maxExperience = 400; //todo 暫時給他
        [BoxGroup("數值")] [SerializeField] public int experience;

        //TODO 需要補充武器數量
        [BoxGroup("背包資料")] [SerializeField] public List<string> bagWeaponData;
        [BoxGroup("技能列表")] [SerializeField] public List<Skill.Skill> skillData;

        private void OnEnable()
        {
            // 在GameDataSetting啟用時訂閱事件
            MoneyEventMediator.OnEnemyDeathGetMoney += UpdateMoneyValuesOnEnemyDeathGetMoney;
            MoneyEventMediator.OnDoGachaConsumeLoot += UpdateMoneyValuesOnDoGachaConsumeLoot;
            ExperienceEventMediator.OnEnemyDeathGetExperience += UpdateExperienceValuesOnEnemyDeathGetMoney;
            WeaponEventMediator.OnGachaGetWeapon += UpdateBagWeaponDataOnDoGachaGetWeapon;
        }

        private void OnDisable()
        {
            // 在GameDataSetting禁用時取消訂閱事件，以避免內存洩漏
            MoneyEventMediator.OnEnemyDeathGetMoney -= UpdateMoneyValuesOnEnemyDeathGetMoney;
            MoneyEventMediator.OnDoGachaConsumeLoot -= UpdateMoneyValuesOnDoGachaConsumeLoot;
            ExperienceEventMediator.OnEnemyDeathGetExperience -= UpdateExperienceValuesOnEnemyDeathGetMoney;
            WeaponEventMediator.OnGachaGetWeapon -= UpdateBagWeaponDataOnDoGachaGetWeapon;
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
            // 更新掉落物數值
            loot += lootIncrement;

            MoneyEventCenter.Broadcast(MoneyEventType.AddLoot, loot);
        }

        private void UpdateExperienceValuesOnEnemyDeathGetMoney(int experience)
        {
            // 更新經驗條
            this.experience += experience;
            var experienceValue = this.experience / (float)maxExperience;
            if (this.experience >= maxExperience)
            {
                this.experience -= maxExperience;

                ExperienceEventCenter.Broadcast(ExperienceEventType.LeverUp, 1f);
            }

            ExperienceEventCenter.Broadcast(ExperienceEventType.UpdataExperience, experienceValue);
        }

        private void UpdateBagWeaponDataOnDoGachaGetWeapon(string weaponName)
        {
            // 更新武器數量
            foreach (var weapon in bagWeaponData)
            {
                if (weapon == weaponName)
                {
                    return;
                }
            }

            bagWeaponData.Add(weaponName);

            WeaponEventCenter.Broadcast(WeaponEventType.UpdataWeaponData, weaponName);
        }
    }
}