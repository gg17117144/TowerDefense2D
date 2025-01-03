using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Script.ScriptObject.Script
{
    [CreateAssetMenu(fileName = "AllGameRoundData", menuName = "TowerDefense2D/Create Game Round Data")]
    public class AllGameRoundData : ScriptableObject
    {
        public List<GameRoundData> gameRoundDataList;

        // 當數據變更時更新 roundNum
        private void OnValidate()
        {
            if (gameRoundDataList == null) return;

            for (int i = 0; i < gameRoundDataList.Count; i++)
            {
                gameRoundDataList[i].roundNum = i; // 同步 roundNum
            }
        }
    }

    [Serializable]
    public class GameRoundData
    {
        [Header("回合資訊")] public int roundNum; // 回合次數

        [Header("敵人資訊")] public int enemyCount; // 敵人數量
        public int eliteEnemyCount; // 菁英敵人數量

        [Header("船的資訊")] public int shipCount; // 船的數量

        // 顯示資訊的函式（可選）
        public void DisplayRoundInfo()
        {
            Debug.Log($"回合次數: {roundNum}, 敵人數量: ={enemyCount}, 菁英敵人數量: ={eliteEnemyCount}, 船的數量={shipCount}");
        }
        
        // 拷貝構造函數
        public GameRoundData(GameRoundData other)
        {
            roundNum = other.roundNum;
            enemyCount = other.enemyCount;
            eliteEnemyCount = other.eliteEnemyCount;
            shipCount = other.shipCount;
        }
    }
}