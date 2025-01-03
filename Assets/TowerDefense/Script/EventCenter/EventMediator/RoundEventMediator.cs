using System;
using TowerDefense.Script.ScriptObject.Script;

namespace TowerDefense.Script.EventCenter.EventMediator
{
    public static class RoundEventMediator
    {
        public static event Action<GameRoundData> OnStartRound;

        public static void DoStartRound(GameRoundData gameRoundData)
        {
            OnStartRound?.Invoke(gameRoundData);
        }

        public static event Action<GameRoundData> OnStartCreateEnemy;

        public static void DoStartCreateEnemy(GameRoundData gameRoundData)
        {
            OnStartCreateEnemy?.Invoke(gameRoundData);
        }
    }
}