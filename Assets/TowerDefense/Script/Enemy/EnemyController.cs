using System.Collections;
using DG.Tweening;
using NaughtyAttributes;
using TowerDefense.Script.DefenseMechanism;
using TowerDefense.Script.EventCenter;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityHFSM;

namespace TowerDefense.Script.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public EnemySettingData enemySettingData;

        private StateMachine _fsm;
        private Transform _heroTransform;
        private Animator _animator;
        
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip walkSound;
        [SerializeField] private AudioClip hurtSound;
        [SerializeField] private GameObject deadPrefab;

        [Header("數值")] [SerializeField] private int _hp;

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
            _fsm.AddState("Dead", onLogic: state => TempDead());
            _fsm.SetStartState("ChaseHero");
            _fsm.Init();
            
            _animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = walkSound;
            audioSource.Play();
        }

        void TempDead()
        {
            
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
            DamageEffect();
            // Debug.Log($"怪物:{gameObject.name}受了{damageAmount}點傷害，目前血量剩餘{_hp}");
            //TODO 需要跳出UI字樣
            if (_hp <= 0)
            {
                // TODO 需要更換物件池
                DamageSound();
                DestroyHeroList();
                MoneyEventMediator.MoneyEnemyDeathNotify(enemySettingData.bounty,enemySettingData.loot);
                ExperienceEventMediator.ExperienceEnemyDeathNotify(10);
                _fsm.RequestStateChange("Dead");
                // transform.GetChild(0).DOScale(0, 0.5f);
                Instantiate(deadPrefab,transform.position,Quaternion.identity);
                Dead();
                // Invoke(nameof(Dead),1f);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"Weapon"))
            {
                DamageTaken(other.GetComponent<WeaponController>().DamageAmount);
            }
        }

        void DestroyHeroList()
        {
            // Debug.Log("清空Hero追蹤目標");
            // Hero.Hero.Instance.enemyList.RemoveAt(0);
        }
        
        private void DamageSound()
        {
            StartCoroutine(nameof(StartDamageSound));
        }

        IEnumerator StartDamageSound()
        {
            audioSource.clip = hurtSound;
            audioSource.Play();
            _animator.Play("Dead");
            yield return new WaitForSeconds(0.5f);
            // audioSource.clip = walkSound;
            // audioSource.Play();
            // TODO 先暫時寫在這裡
        }

        public void Dead()
        {
            Destroy(gameObject.transform.parent.gameObject);
        }

        private void DamageEffect()
        {
            StartCoroutine(nameof(StartDamageEffect));
        }

        IEnumerator StartDamageEffect()
        {
            transform.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.1f);
            transform.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}