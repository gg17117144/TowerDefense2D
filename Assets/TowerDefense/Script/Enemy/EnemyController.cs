using System;
using NaughtyAttributes;
using TowerDefense.Script.DefenseMechanism;
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
        
        [Header("數值")] 
        [SerializeField] private int _hp;

        public void Initialize(EnemySettingData enemySo)
        {
            enemySettingData = enemySo;
            _hp = enemySettingData.hp;
        }
        
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
            //TODO 攻擊英雄的動畫以及生成武器丟出去
            Debug.Log("AttackHero");
        }

        void ChaseHero()
        {
            //TODO 往英雄的方向前進
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

        private void DamageTaken(int damageAmount)
        {
            _hp -= damageAmount;
            // Debug.Log($"怪物:{gameObject.name}受了{damageAmount}點傷害，目前血量剩餘{_hp}");
            //TODO 需要跳出UI字樣
            if (_hp <= 0)
            {
                DestroyObject();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"Weapon"))
            {
                DamageTaken(other.GetComponent<WeaponController>().DamageAmount);
            }
        }

        private void DestroyObject()
        {
            //TODO 需要更改成物件池的作法
            Destroy(gameObject);
        }
    }
}