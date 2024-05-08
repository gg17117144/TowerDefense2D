using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [CreateAssetMenu(fileName = "EnemySettingSo", menuName = "TowerDefense2D/Create EnemySo")]
    public class EnemySettingData : ScriptableObject
    {
        [Header("數值")] public int hp;
        public float moveSpeed;
        public float attackSpeed;
        public int bounty;
        public int loot;

        [SerializeField]
        public enum EnemyTypes
        {
            Saber,
            Archer
        }

        [Header("物件")] public GameObject weapon;
        public GameObject enemyPrefab;
    }
}