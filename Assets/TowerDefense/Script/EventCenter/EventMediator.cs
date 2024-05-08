namespace TowerDefense.Script.EventCenter
{
    public class MoneyEventMediator
    {
        public static event System.Action<int, int> OnEnemyDeathGetMoney;

        public static void MoneyEnemyDeathNotify(int bounty, int loopIncrement)
        {
            OnEnemyDeathGetMoney?.Invoke(bounty, loopIncrement);
        }
    }
    
    public class ExperienceEventMediator
    {
        public static event System.Action<int> OnEnemyDeathGetExperience;

        public static void ExperienceEnemyDeathNotify(int Experience)
        {
            OnEnemyDeathGetExperience?.Invoke(Experience);
        }
    }
}