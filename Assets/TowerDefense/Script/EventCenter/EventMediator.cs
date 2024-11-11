using JetBrains.Annotations;
using UnityEngine;

namespace TowerDefense.Script.EventCenter
{
    public static class MoneyEventMediator
    {
        public static event System.Action<int, int> OnEnemyDeathGetMoney;

        public static void MoneyEnemyDeathNotify(int bounty, int loopIncrement)
        {
            OnEnemyDeathGetMoney?.Invoke(bounty, loopIncrement);
        }
        
        public static event System.Action<int> OnDoGachaConsumeLoot;

        public static void DoGachaConsumeLoot(int loot)
        {
            OnDoGachaConsumeLoot?.Invoke(loot);
        }
    }
    
    public static class ExperienceEventMediator
    {
        public static event System.Action<int> OnEnemyDeathGetExperience;

        public static void ExperienceEnemyDeathNotify(int experience)
        {
            OnEnemyDeathGetExperience?.Invoke(experience);
        }
    }
    
    public static class WeaponEventMediator
    {
        public static event System.Action<string> OnGachaGetWeapon;

        public static void DoGachaGetWeapon(string weaponName)
        {
            OnGachaGetWeapon?.Invoke(weaponName);
        }
    }
    
    public static class EnemyEventMediator
    {
        [CanBeNull] public static event System.Action<Transform> OnEnemyDead;

        public static void DoEnemyDead(Transform enemy)
        {
            OnEnemyDead?.Invoke(enemy);
        }
    }
}