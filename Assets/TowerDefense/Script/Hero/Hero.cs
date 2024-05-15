using System.Collections.Generic;
using TowerDefense.Script.DefenseMechanism;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Script.Hero
{
    public class Hero : MonoBehaviour
    {
        public static Hero Instance;
        [SerializeField] private HeroSettingSo heroSetting;
        [SerializeField] public List<Transform> enemyList = new List<Transform>();
        private Transform _weaponPool;
        private float _stopTime = 0;

        [SerializeField] private Transform shootTransform;

        private Animator _animator;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _weaponPool = GameObject.Find("WeaponPool").transform;
            shootTransform = transform.Find("shootTransform").transform;
        }

        private void Update()
        {
            _stopTime += Time.deltaTime;
            if (enemyList.Count >= 1 &&
                _stopTime >= 1 - heroSetting.heroSetting.attackSpeed * 0.01)
            {
                Defense(enemyList[0]);
                _stopTime = 0;
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i] == null)
                {
                    enemyList.Remove(enemyList[i]);
                }
            }

            if (heroSetting.heroSetting.hp <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
        
        public void Dead()
        {
            DestroyObject(gameObject.transform.parent);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(nameof(Enemy)))
            {
                enemyList.Add(other.transform);
            }
        }

        private void Defense(Transform target)
        {
            _animator.Play("Attack");
            Track(target);
        }

        private void Track(Transform target)
        {
            var weaponSo = heroSetting.defenseMechanismSetting.weaponSettingSo;
            var shootTransformPosition = shootTransform.position;

            var weaponSettingPrefab = weaponSo.weaponSetting.prefab;
            var weaponInstantiate = Instantiate(weaponSettingPrefab, shootTransformPosition,
                Quaternion.identity, _weaponPool);
            WeaponController weaponController = weaponInstantiate.AddComponent<WeaponController>();
            weaponController.Initialize(weaponSo, target);
        }

        public void SetWeapon(WeaponSettingSo weaponSettingSo)
        {
            heroSetting.defenseMechanismSetting.weaponSettingSo = weaponSettingSo;
        }
    }
}