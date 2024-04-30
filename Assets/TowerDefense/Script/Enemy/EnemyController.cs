using System;
using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.Serialization;
using UnityHFSM;

namespace TowerDefense.Script.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public EnemySettingData enemySettingData;

        private StateMachine _fsm;

        private Transform _heroTransform;

        private Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _heroTransform = GameObject.FindWithTag("Hero").transform;

            _fsm = new StateMachine();
            _fsm.AddState("ChaseHero", onLogic: state => ChaseHero());
            _fsm.AddState("AttackHero", onLogic: state => AttackHero());
            _fsm.SetStartState("ChaseHero");
            _fsm.Init();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ReferenceEquals(_fsm, null))
                _fsm.OnLogic();
        }

        [Button]
        void AttackHero()
        {
            // TODO 攻擊英雄的動畫以及生成武器丟出去
            Debug.Log("AttackHero");
        }

        void ChaseHero()
        {
            // TODO 往英雄的方向前進
            if (!ReferenceEquals(_heroTransform, null))
            {
                // 計算距離
                var thisPosition = transform.position;
                var heroPosition = _heroTransform.transform.position;
                // float distance = Vector2.Distance(thisPosition, heroPosition);
                // 計算怪物要移動的方向
                Vector2 moveDirection = (heroPosition - thisPosition).normalized;

                // 移動怪物
                transform.position = Vector2.MoveTowards(thisPosition,
                    thisPosition + (Vector3)moveDirection, enemySettingData.moveSpeed);
            }
        }
    }
}