using JetBrains.Annotations;
using UnityEngine;

namespace TowerDefense.Script.EventCenter.EventMediator
{
    public static class EnemyEventMediator
    {
        [CanBeNull] public static event System.Action<Transform> OnEnemyDead;
        /// <summary>
        /// 當一般敵人死亡
        /// </summary>
        /// <param name="enemy"></param>
        public static void DoEnemyDead(Transform enemy)
        {
            OnEnemyDead?.Invoke(enemy);
        }
        
        [CanBeNull] public static event System.Action<Transform> OnEliteEnemyPhase2;
        /// <summary>
        /// 當菁英敵人進入階段2
        /// </summary>
        /// <param name="enemy"></param>
        public static void DoEliteEnemyPhase2(Transform enemy)
        {
            OnEliteEnemyPhase2?.Invoke(enemy);
        }
    }
}