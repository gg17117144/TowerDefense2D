namespace TowerDefense.Script.EventCenter.EventMediator
{
    public static class RoundEventMediator
    {
        public static event System.Action<int> OnStartRound;

        public static void DoStartRound(int roundValue)
        {
            OnStartRound?.Invoke(roundValue);
        }
        
        public static event System.Action<bool> OnStartCreateEnemy;

        public static void DoStartCreateEnemy(bool isCreate)
        {
            OnStartCreateEnemy?.Invoke(isCreate);
        }
    }
}