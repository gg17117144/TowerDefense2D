using System;
using NaughtyAttributes;
// using TowerDefense.Script.Tools;
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
        [Required] public string name;
        [Required] public Sprite icon;
        [Required] public int damage;
        [Required] public float speed;
        [Required] public GameObject prefab;
        [Required] public WeaponType weaponType;
    }

    [CreateAssetMenu(fileName = "WeaponSettingSo", menuName = "TowerDefense2D/Create WeaponSo")]
    public class WeaponSettingSo : ScriptableObject
    {
        public WeaponSetting weaponSetting;

        [Button]
        void AutoMatch()
        {
            Debug.Log($"weaponSetting.name:{weaponSetting.name}");
            var autoMatchIcon = AutoMatchIcon(weaponSetting.name);
            var autoMatchPrefab = AutoMatchPrefab(weaponSetting.name);
            weaponSetting.icon = autoMatchIcon;
            weaponSetting.prefab = autoMatchPrefab;
        }
        
        Sprite AutoMatchIcon(string weaponName)
        {
            string folderPath = "Assets/TowerDefense/Sprite/Weapon";
            string[] prefabPaths = AssetDatabase.FindAssets("t:Sprite", new[] { folderPath });
            foreach (var path in prefabPaths)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(path);
                Sprite prefab = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
    
                if (prefab.name.Contains(weaponName) && prefab.name.Contains("frame"))
                {
                    Debug.Log("找到了相對應的Sprite");
                    return prefab;
                }
            }

            Debug.Log("沒有找到相對應的圖示");
            return null;
        }
        
        GameObject AutoMatchPrefab(string weaponName)
        {
            string folderPath = "Assets/TowerDefense/Prefab";
            string[] prefabPaths = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });
            foreach (var path in prefabPaths)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(path);
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);

                if (prefab.name.Contains(weaponName))
                {
                    
                    Debug.Log("有抓到物件Prefab");
                    return prefab;
                }
            }
            Debug.Log("沒有找到相對應的物件");
            return null;
        }
    }
    
}