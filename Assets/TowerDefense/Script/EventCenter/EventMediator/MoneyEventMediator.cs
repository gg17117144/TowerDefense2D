namespace TowerDefense.Script.EventCenter.EventMediator
{
    public static class MoneyEventMediator
    {
        public static event System.Action<int, int> OnEnemyDeathGetMoney;

        public static void MoneyEnemyDeathNotify(int bounty, int loopIncrement)
        {
            OnEnemyDeathGetMoney?.Invoke(bounty, loopIncrement);
        }
        
        public static event System.Action<int> OnDoGachaConsumeLoot;

        public static void DoGachaConsumeLoot(int loot)
        {
            OnDoGachaConsumeLoot?.Invoke(loot);
        }
    }
}