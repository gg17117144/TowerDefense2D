using System.Collections.Generic;
using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TowerDefense.Script.Enemy
{
    public class CreateEnemy : MonoBehaviour
    {
        [SerializeField] private List<EnemySettingData> enemySoList;
        private Transform _enemyPool;
        private void Start()
        {
            _enemyPool = GameObject.Find("EnemyPool").transform;
            Invoke(nameof(StartCreate), 1f);
        }

        [Button]
        public void StartCreate()
        {
            InvokeRepeating(nameof(Create), 0, 3f);
        }

        [Button]
        public void StopCreate()
        {
            CancelInvoke(nameof(Create));
        }

        [Button]
        void Create()
        {
            var pos = transform.position;
            var randomY = Random.Range(-5f, 5f);
            pos += new Vector3(0, randomY, 0);

            var randomNum = Random.Range(0, enemySoList.Count);
            var enemyPrefab = enemySoList[randomNum].enemyPrefab;
            var enemy = GetEnemyFromPool(enemyPrefab.name);
            if (enemy == null) 
            {
                enemy = Instantiate(enemyPrefab, pos,
                    Quaternion.identity, _enemyPool);
            }
            enemy.transform.position = pos;
            enemy.transform.rotation = Quaternion.identity;
            enemy.GetComponentInChildren<EnemyController>().Initialize(enemySoList[randomNum]);
        }
        
        private GameObject GetEnemyFromPool(string enemyName)
        {
            foreach (Transform enemy in _enemyPool)
            {
                if (!enemy.gameObject.activeInHierarchy && enemy.name.Contains(enemyName)) // 檢查物件是否關閉
                {
                    enemy.gameObject.SetActive(true); // 啟用物件
                    // 在這裡做額外的設定，如位置、旋轉等
                    return enemy.gameObject; // 返回這個物件
                }
            }

            // 如果沒有可用物件，返回 null 或考慮擴充池
            return null;
        }
    }
}