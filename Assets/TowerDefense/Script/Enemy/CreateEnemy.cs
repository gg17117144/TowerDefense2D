using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using TowerDefense.Script.EventCenter.EventMediator;
using TowerDefense.Script.ScriptObject.Script;
using TowerDefense.Script.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TowerDefense.Script.Enemy
{
    public class CreateEnemy : MonoBehaviour
    {
        [SerializeField] private List<EnemySettingData> enemySoList;
        [SerializeField] private List<EnemySettingData> eliteEnemySoList;
        private Transform _enemyPool; // 物件池Transform

        private CancellationTokenSource _cancellationTokenSource; // 用來取消任務的 CancellationTokenSource

        private void OnEnable()
        {
            _enemyPool = GameObject.Find("EnemyPool").transform;
            RoundEventMediator.OnStartCreateEnemy += CheckIsCreated;
            EnemyEventMediator.OnEliteEnemyPhase2 += CreateBearEnemy;
        }

        private void OnDestroy()
        {
            RoundEventMediator.OnStartCreateEnemy -= CheckIsCreated;
            EnemyEventMediator.OnEliteEnemyPhase2 -= CreateBearEnemy;
        }

        // 根據是否創建敵人來決定是否開始或停止創建
        private void CheckIsCreated(GameRoundData gameRoundData)
        {
            // 如果已經創建敵人，則開始生成敵人
            if (gameRoundData != null)
            {
                StartCreate(gameRoundData);
            }
            else
            {
                StopCreate();
            }
        }

        private async void StartCreate(GameRoundData gameRoundData)
        {
            // 如果之前有啟動過創建任務，先取消它
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose(); // 清理資源
            _cancellationTokenSource = new CancellationTokenSource(); // 創建新的 CancellationTokenSource

            await StartCreateEnemy(gameRoundData.enemyCount, 3f);
            await StartCreateEliteEnemy(gameRoundData.eliteEnemyCount, 15f);
        }

        [Button]
        private void StopCreate()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async UniTask StartCreateEnemy(int count, float delayTime, CancellationToken cancellationToken = new CancellationToken())
        {
            if (count <= 0)
                return;
            for (int i = 0; i < count; i++)
            {
                // 創建敵人邏輯
                CreateOneEnemy();

                try
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(delayTime),
                        cancellationToken: cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    // 取消時可以選擇記錄或處理，然後直接退出循環
                    break;
                }
            }
        }

        private async UniTask StartCreateEliteEnemy(int count, float delayTime, CancellationToken cancellationToken = new CancellationToken())
        {
            if (count <= 0)
                return;
            for (int i = 0; i < count; i++)
            {
                // 創建敵人邏輯
                CreateOneEliteEnemy();

                try
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(delayTime),
                        cancellationToken: cancellationToken); // 支持取消的延遲
                }
                catch (TaskCanceledException)
                {
                    // 取消時可以選擇記錄或處理，然後直接退出循環
                    break;
                }
            }
        }

        [Button]
        private void CreateOneEnemy()
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

        private void CreateBearEnemy(Transform spawnTransform)
        {
            var enemyPrefab = enemySoList[2].enemyPrefab;
            var enemy = GetEnemyFromPool(enemyPrefab.name);
            if (enemy == null)
            {
                enemy = Instantiate(enemyPrefab, spawnTransform.position,
                    Quaternion.identity, _enemyPool);
            }

            enemy.transform.position = spawnTransform.position;
            enemy.transform.rotation = Quaternion.identity;
            enemy.GetComponentInChildren<EnemyController>().Initialize(enemySoList[2]);
        }

        [Button]
        void CreateOneEliteEnemy()
        {
            var pos = transform.position;
            var randomY = Random.Range(-5f, 5f);
            pos += new Vector3(0, randomY, 0);

            var randomNum = Random.Range(0, eliteEnemySoList.Count);
            var enemyPrefab = eliteEnemySoList[randomNum].enemyPrefab;
            var enemy = GetEnemyFromPool(enemyPrefab.name);
            if (enemy == null)
            {
                enemy = Instantiate(enemyPrefab, pos,
                    Quaternion.identity, _enemyPool);
            }

            enemy.transform.position = pos;
            enemy.transform.rotation = Quaternion.identity;
            enemy.GetComponentInChildren<EnemyController>().Initialize(eliteEnemySoList[randomNum]);
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