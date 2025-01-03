using NaughtyAttributes;
using TowerDefense.Script.Enemy;
using TowerDefense.Script.EventCenter.EventMediator;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;

namespace TowerDefense.Script
{
    public class GameRoundController : MonoBehaviour
    {
        [SerializeField] private AllGameRoundData allGameRoundData;
        [SerializeField] [ReadOnly] private GameRoundData nowGameRoundData;

        private void OnEnable()
        {
            RoundEventMediator.OnStartRound += OnStartRoundHandler;
            EnemyEventMediator.OnEnemyDead += UpdateRoundSchedule;
        }

        private void OnDestroy()
        {
            RoundEventMediator.OnStartRound -= OnStartRoundHandler;
            EnemyEventMediator.OnEnemyDead -= UpdateRoundSchedule;
        }

        // 將事件邏輯提取到具名方法
        private void OnStartRoundHandler(GameRoundData gameRoundData)
        {
            // PrintRoundInfo(gameRoundData.roundNum);
        }

        private void UpdateRoundSchedule(Transform enemyTransform)
        {
            switch (enemyTransform.transform.GetComponent<EnemyController>().enemySettingData.enemyTypes)
            {
                case EnemyTypes.Normal:
                    nowGameRoundData.enemyCount--;
                    break;
                case EnemyTypes.Elite:
                    nowGameRoundData.eliteEnemyCount--;
                    break;
            }

            if (nowGameRoundData.enemyCount <= 0 && nowGameRoundData.eliteEnemyCount <= 0)
            {
                PlayNextRound();
                Debug.Log("回合結束");
            }
        }

        private void PrintRoundInfo(int roundNum)
        {
            var gameRoundData = allGameRoundData.gameRoundDataList[roundNum];
            Debug.Log(
                $"目前回合次數:{gameRoundData.roundNum} \n 生成的敵人數量:{gameRoundData.enemyCount} \n 生成的菁英敵人數量:{gameRoundData.eliteEnemyCount} \n 生成船的數量:{gameRoundData.shipCount}");
        }

        [SerializeField] private int testRoundNum;

        [Button("從階段{testRoundNum}回合開始")]
        private void StartRound()
        {
            StartRound(testRoundNum);
        }

        [Button("從階段0新手訓練開始")]
        private void StartNewRound()
        {
            StartRound(0);
        }

        private void StartRound(int roundNum)
        {
            PrintRoundInfo(roundNum);
            RoundEventMediator.DoStartRound(allGameRoundData.gameRoundDataList[roundNum]);
            nowGameRoundData = new GameRoundData(allGameRoundData.gameRoundDataList[roundNum]);
        }

        [Button]
        public void PlayNextRound()
        {
            nowGameRoundData.roundNum++;
            var newRoundNum = nowGameRoundData.roundNum;
            Debug.Log($"nowGameRoundData.roundNum:{nowGameRoundData.roundNum},newRoundNum:{newRoundNum}");
            if (newRoundNum > allGameRoundData.gameRoundDataList.Count)
                newRoundNum = allGameRoundData.gameRoundDataList.Count; // 因為目前ALLGameRoundDataList的資料不齊全暫時先這樣處理
            // todo 需要修改這裡暫時處理的部分
            StartRound(newRoundNum);
            // RoundEventMediator.DoStartRound(allGameRoundData.gameRoundDataList[newRoundNum]);
        }
    }
}