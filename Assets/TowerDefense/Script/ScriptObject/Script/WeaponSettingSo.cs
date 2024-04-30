using System;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class WeaponSetting
    {
        public int damage;
        public float speed;

        public GameObject prefab;
    }

    [CreateAssetMenu(fileName = "WeaponSettingSo", menuName = "TowerDefense2D/Create WeaponSo")]
    public class WeaponSettingSo : ScriptableObject
    {
        public WeaponSetting weaponSetting;
    }
}