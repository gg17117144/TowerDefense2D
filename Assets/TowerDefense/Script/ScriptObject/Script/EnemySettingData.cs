using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerDefense.Script.ScriptObject.Script
{
    [CreateAssetMenu(fileName = "EnemySettingSo", menuName = "TowerDefense2D/Create EnemySo")]
    public class EnemySettingData : ScriptableObject
    {
        [Header("數值")] public int hp;
        public float moveSpeed;
        public float attackSpeed;
        
        [SerializeField]
        public enum EnemyTypes
        {
            Saber,Archer
        }

        [Header("物件")] public GameObject weapon;
        public GameObject enemyPrefab;
    }
}