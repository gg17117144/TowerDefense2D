using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class Enemy
    {
        public int hp;
        public int moveSpeed;
        
        public GameObject weapon;
        public int attackDamage;
        public float attackSpeed;

        public GameObject enemyPrefab;
    }

    [CreateAssetMenu(fileName = "EnemySo",menuName = "TowerDefense2D/Create EnemySo")]
    public class EnemySo : ScriptableObject
    {
        public Enemy enemy;
    }
}