using JetBrains.Annotations;
using UnityEngine;

namespace TowerDefense.Script.EventCenter.EventMediator
{
    public static class EnemyEventMediator
    {
        [CanBeNull] public static event System.Action<Transform> OnEnemyDead;

        public static void DoEnemyDead(Transform enemy)
        {
            OnEnemyDead?.Invoke(enemy);
        }
    }
}