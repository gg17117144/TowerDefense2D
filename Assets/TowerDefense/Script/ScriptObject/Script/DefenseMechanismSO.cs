using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class DefenseMechanism
    {
        public GameObject weapon;
        public int attackDamage;
        public float attackSpeed;

        public GameObject defenseMechanismPrefab;
    }

    [CreateAssetMenu(fileName = "New DefenseMechanismSO",menuName = "TowerDefense2D/Create DefenseMechanismSO")]
    public class DefenseMechanismSo : ScriptableObject
    {
        public DefenseMechanism defenseMechanism;
    }
}