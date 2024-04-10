using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject
{
    [Serializable]
    public class Hero
    {
        public int hp;
    }

    [CreateAssetMenu(fileName = "New HeroSO",menuName = "TowerDefense2D/Create HeroSO")]
    public class HeroSo : ScriptableObject
    {
        public Hero hero;
        public DefenseMechanism defenseMechanism;
    }
}