using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [CreateAssetMenu(fileName = "EnemySettingSo", menuName = "TowerDefense2D/Create EnemySo")]
    public class EnemySettingData : ScriptableObject
    {
        [Header("數值")] public int hp;
        public float moveSpeed;
        public float attackSpeed;
        public float damage;
        public int bounty;
        public int loot;
        public EnemyAttackTypes enemyAttackTypes;
        public EnemyTypes enemyTypes;
        [Header("物件")] public GameObject weapon;
        public GameObject enemyPrefab;
    }
    
    [SerializeField]
    public enum EnemyAttackTypes
    {
        Saber,
        Archer
    }
        
    [SerializeField]
    public enum EnemyTypes
    {
        Normal,
        Elite
    }
}