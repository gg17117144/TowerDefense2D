using System;
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

        private void Start()
        {
            Invoke(nameof(StartCreate),8f);
            // StartCreate();
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
            var enemyPool = GameObject.Find("EnemyPool");
            var pos = transform.position;
            var randomY = Random.Range(-5f, 5f);
            pos += new Vector3(0, randomY, 0);

            var randomNum = Random.Range(0, enemySoList.Count);
            var enemyInstantiate = Instantiate(enemySoList[randomNum].enemyPrefab, pos,
                Quaternion.identity, enemyPool.transform);
            enemyInstantiate.GetComponentInChildren<EnemyController>().Initialize(enemySoList[randomNum]);
        }
    }
}