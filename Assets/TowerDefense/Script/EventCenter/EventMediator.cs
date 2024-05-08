namespace TowerDefense.Script.EventCenter
{
    public class MoneyEventMediator
    {
        public static event System.Action<int, int> OnEnemyDeath;

        public static void EnemyDeathNotify(int bounty, int loopIncrement)
        {
            OnEnemyDeath?.Invoke(bounty, loopIncrement);
        }
    }
}