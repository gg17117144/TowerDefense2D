using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class HeroSetting
    {
        public int hp;
        public GameObject weapon;
        public float attackSpeed;

        public GameObject heroPrefab;
    }

    [CreateAssetMenu(fileName = "HeroSettingSo", menuName = "TowerDefense2D/Create HeroSO")]
    public class HeroSettingSo : ScriptableObject
    {
        public HeroSetting heroSetting;
        public DefenseMechanismSetting defenseMechanismSetting;
    }
}