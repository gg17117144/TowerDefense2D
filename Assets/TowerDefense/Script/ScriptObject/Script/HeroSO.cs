using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class Hero
    {
        public int hp;
    }

    [CreateAssetMenu(fileName = "HeroSO",menuName = "TowerDefense2D/Create HeroSO")]
    public class HeroSo : ScriptableObject
    {
        public Hero hero;
        public DefenseMechanism defenseMechanism;
    }
}