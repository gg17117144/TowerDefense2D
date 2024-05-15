using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEditor;
using UnityEngine;

namespace TowerDefense.Script
{
    public class AllGameData : MonoBehaviour
    {
        public static AllGameData instance;

        public List<WeaponSettingSo> allWeaponSettings;
        
        public List<Skill.Skill> allSkillSettings;
        
        private const string FolderPath = "Assets/TowerDefense/Script/ScriptObject"; // 起始資料夾路徑

        private void Awake()
        {
            instance = this;
        }

        [Button]
        void GetAllWeaponSettings()
        {
            //TODO 添加方便的自動抓取武器so
        }
    }
}
