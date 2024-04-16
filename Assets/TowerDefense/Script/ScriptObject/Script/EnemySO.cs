using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class EnemySetting
    {
        [Header("數值")] public int hp;
        public float moveSpeed;
        public float attackSpeed;

        [SerializeField] [Dropdown("_enemyTypes")]
        public string enemyType;

        private List<string> _enemyTypes = new List<string>()
        {
            "Saber", "Archer"
        };

        [Header("物件")] public GameObject weapon;
        public GameObject enemyPrefab;
    }

    [CreateAssetMenu(fileName = "EnemySo", menuName = "TowerDefense2D/Create EnemySo")]
    public class EnemySo : ScriptableObject
    {
        public EnemySetting enemySetting;
    }
}