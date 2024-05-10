using System;
using NaughtyAttributes;
using UnityEditor;
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
        [Required] public Sprite icon;
        [Required] public int damage;
        [Required] public float speed;
        [Required] public GameObject prefab;
        [Required] public WeaponType weaponType;
        
        [Button]
        void AutoMatch()
        {
            
        }
        
        [Button]
        void AutoMatchIcon()
        {
            
        }
        
        [Button]
        void AutoMatchPrefab()
        {
            string folderPath = "Assets/TowerDefense/Prefab";
            string[] prefabPaths = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });
            GameObject[] prefabs = new GameObject[prefabPaths.Length];
            foreach (var prefab in prefabs)
            {
                if (prefab.name.Contains(name))
                {
                    Debug.Log("有抓到物件");
                }
            }
        }
    }

    [CreateAssetMenu(fileName = "WeaponSettingSo", menuName = "TowerDefense2D/Create WeaponSo")]
    public class WeaponSettingSo : ScriptableObject
    {
        public WeaponSetting weaponSetting;
    }
    
}