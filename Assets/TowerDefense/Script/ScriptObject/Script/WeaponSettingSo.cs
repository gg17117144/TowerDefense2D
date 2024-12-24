using System;
using NaughtyAttributes;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    public enum WeaponType
    {
        Rotate,
        NotRotate
    }
    
    public enum WeaponLevel
    {
        White,
        Blue,
        Purple,
        Red
    }

    [Serializable]
    public class WeaponSetting
    {
        [Required] public string name;
        [ShowAssetPreview][Required] public Sprite icon;
        [Required] public int damage;
        [Required] public float speed;
        [ShowAssetPreview][Required] public Sprite sprite;
        [Required] public GameObject prefab;
        [Required] public WeaponType weaponType;
        [Required] public WeaponLevel weaponLevel;
        [Required] public Vector2 colliderOffset;
        [Required] public float colliderRadius;
    }

    [CreateAssetMenu(fileName = "WeaponSettingSo", menuName = "TowerDefense2D/Create WeaponSo")]
    public class WeaponSettingSo : ScriptableObject
    {
        public WeaponSetting weaponSetting;

#if UNITY_EDITOR
        [Button]
        void AutoMatch()
        {
            Debug.Log($"weaponSetting.name:{weaponSetting.name}");
            // var autoMatchIcon = AutoMatchIcon(weaponName);
            // var autoMatchPrefab = AutoMatchPrefab(weaponName);
            // var autoMatchSprite = AutoMatchSprite(weaponName);
            weaponSetting.icon = AutoMatchIcon(weaponSetting.name);
            weaponSetting.sprite = AutoMatchSprite(weaponSetting.name);
            weaponSetting.prefab = AutoMatchPrefab(weaponSetting.name);
            AutoMatchCollider(weaponSetting.prefab);
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
        
        Sprite AutoMatchSprite(string weaponName)
        {
            string folderPath = "Assets/TowerDefense/Sprite/Weapon";
            string[] prefabPaths = AssetDatabase.FindAssets("t:Sprite", new[] { folderPath });
            foreach (var path in prefabPaths)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(path);
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                // !sprite.name.Contains("frame")是為了不尋找frame icon的用途
                if (sprite.name.Contains(weaponName) && !sprite.name.Contains("frame"))
                {
                    Debug.Log("找到了相對應的Sprite");
                    return sprite;
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

        void AutoMatchCollider(GameObject prefab)
        {
            if (!prefab)
                return;
            weaponSetting.colliderOffset = prefab.GetComponent<Collider2D>().offset;
            weaponSetting.colliderRadius = prefab.GetComponent<CircleCollider2D>().radius;
        }
#endif
    }
}