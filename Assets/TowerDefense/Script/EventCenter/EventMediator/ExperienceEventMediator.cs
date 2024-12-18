namespace TowerDefense.Script.EventCenter.EventMediator
{
    public static class ExperienceEventMediator
    {
        public static event System.Action<int> OnEnemyDeathGetExperience;
    
        public static void ExperienceEnemyDeathNotify(int experience)
        {
            OnEnemyDeathGetExperience?.Invoke(experience);
        }
    }
}