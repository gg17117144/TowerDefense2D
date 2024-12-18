using System;

namespace TowerDefense.Script.EventCenter.UIEventCenter
{
    public static class ProgressUIEventMediator
    {
        public static event Action<int, int> OnProgressChange;

        public static void DoProgressChange(int roundValue, int roundTime)
        {
            OnProgressChange?.Invoke(roundValue, roundTime);
        }
    }
}