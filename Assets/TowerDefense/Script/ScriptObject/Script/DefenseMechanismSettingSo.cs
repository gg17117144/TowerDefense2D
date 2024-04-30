using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerDefense.Script.ScriptObject.Script
{
    [Serializable]
    public class DefenseMechanismSetting
    {
        [FormerlySerializedAs("weaponSo")] public WeaponSettingSo weaponSettingSo;
        public float attackSpeed;

        public GameObject defenseMechanismPrefab;
    }

    [CreateAssetMenu(fileName = "DefenseMechanismSettingSo", menuName = "TowerDefense2D/Create DefenseMechanismSO")]
    public class DefenseMechanismSettingSo : ScriptableObject
    {
        public DefenseMechanismSetting defenseMechanismSetting;
        public bool foldout = true; // 新增 foldout 屬性，用於追踪折疊區域的狀態
    }
}