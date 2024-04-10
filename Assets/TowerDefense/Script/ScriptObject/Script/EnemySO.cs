using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class Enemy
    {
        public int hp;
    }

    [CreateAssetMenu(fileName = "New EnemySo",menuName = "TowerDefense2D/Create EnemySo")]
    public class EnemySo : ScriptableObject
    {
        public Enemy enemy;
        public DefenseMechanism defenseMechanism;
    }
}