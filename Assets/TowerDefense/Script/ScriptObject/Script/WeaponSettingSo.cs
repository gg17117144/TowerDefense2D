using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    public enum WeaponType
    {
        Rotate,NotRotate
    }
    
    [Serializable]
    public class WeaponSetting
    {
        public int damage;
        public float speed;

        public GameObject prefab;

        public WeaponType weaponType;
    }

    [CreateAssetMenu(fileName = "WeaponSettingSo", menuName = "TowerDefense2D/Create WeaponSo")]
    public class WeaponSettingSo : ScriptableObject
    {
        public WeaponSetting weaponSetting;
    }
}