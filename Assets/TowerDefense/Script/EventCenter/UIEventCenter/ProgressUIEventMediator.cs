using System;

namespace TowerDefense.Script.EventCenter.UIEventCenter
{
    public static class ProgressUIEventMediator
    {
        public static event Action<int, float> OnProgressChange;

        public static void DoProgressChange(int roundValue, float roundTime)
        {
            OnProgressChange?.Invoke(roundValue, roundTime);
        }
    }
}