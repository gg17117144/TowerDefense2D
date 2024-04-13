using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class Hero
    {
        public int hp;
        public GameObject weapon;
        public int attackDamage;
        public float attackSpeed;

        public GameObject heroPrefab;
    }

    [CreateAssetMenu(fileName = "HeroSO",menuName = "TowerDefense2D/Create HeroSO")]
    public class HeroSo : ScriptableObject
    {
        public Hero hero;
    }
}