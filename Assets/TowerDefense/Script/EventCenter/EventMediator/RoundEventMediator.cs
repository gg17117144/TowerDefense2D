namespace TowerDefense.Script.EventCenter.EventMediator
{
    public static class RoundEventMediator
    {
        public static event System.Action<int> OnStartRound;

        public static void DoStartRound(int roundValue)
        {
            OnStartRound?.Invoke(roundValue);
        }
    }
}