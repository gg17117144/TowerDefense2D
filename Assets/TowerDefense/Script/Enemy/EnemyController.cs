using System.Collections;
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
        private Transform _deadObjectPool;
        private Animator _animator;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip walkSound;
        [SerializeField] private AudioClip hurtSound;
        [SerializeField] private GameObject deadPrefab;

        private GameObject _deadPrefab;

        [Header("數值")] [SerializeField] private int hp;

        public void Initialize(EnemySettingData enemySo)
        {
            enemySettingData = enemySo;
            hp = enemySettingData.hp;
        }

        // Start is called before the first frame update
        void OnEnable()
        {
            _heroTransform = GameObject.FindWithTag("Hero").transform;
            _deadObjectPool = GameObject.Find("DeadObjectPool").transform;

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
            
            transform.GetComponent<SpriteRenderer>().color = Color.white;
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
            hp -= damageAmount;
            DamageEffect();
            //TODO 需要跳出UI字樣
            if (hp <= 0)
            {
                Dead();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"Weapon"))
            {
                DamageTaken(other.GetComponent<WeaponController>().DamageAmount);
            }
        }

        private void Dead()
        {
            DamageSound();
            DamageAnimation();
            DeadEvent();
            DeadReset();
            OpenDeadPrefab();
        }

        private void DamageSound()
        {
            audioSource.clip = hurtSound;
            audioSource.Play();
        }

        private void DamageAnimation()
        {
            _animator.Play("Dead");
        }

        private void DeadEvent()
        {
            MoneyEventMediator.MoneyEnemyDeathNotify(enemySettingData.bounty, enemySettingData.loot);
            ExperienceEventMediator.ExperienceEnemyDeathNotify(10);
            EnemyEventMediator.DoEnemyDead(transform);
        }

        private void DeadReset()
        {
            _fsm.RequestStateChange("Dead");
            transform.gameObject.SetActive(false);
        }

        private void OpenDeadPrefab()
        {
            if (_deadPrefab == null)
            {
                _deadPrefab = Instantiate(deadPrefab, transform.position, Quaternion.identity, _deadObjectPool);
            }
            else
            {
                _deadPrefab.SetActive(true);
            }

            // 將死亡物件移動到怪物原點
            _deadPrefab.transform.position = transform.position;
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