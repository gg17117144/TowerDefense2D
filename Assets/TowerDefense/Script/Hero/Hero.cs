using System.Collections.Generic;
using System.Linq;
using TowerDefense.Script.DefenseMechanism;
using TowerDefense.Script.EventCenter;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Script.Hero
{
    public class Hero : MonoBehaviour
    {
        public static Hero instance;
        [SerializeField] private HeroSettingSo heroSetting;
        [SerializeField] public List<Transform> enemyList = new List<Transform>();
        private float _stopTime = 0;
        private Transform _weaponPool;
        private Transform _shootTransform;
        private Animator _animator;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _weaponPool = transform.Find("WeaponPool").transform;
            _shootTransform = transform.Find("shootTransform").transform;

            EnemyEventMediator.OnEnemyDead += RemoveEnemyList;
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

            if (heroSetting.heroSetting.hp <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        private void RemoveEnemyList(Transform enemy)
        {
            enemyList.Remove(enemy);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(nameof(Enemy)))
            {
                Debug.Log("探索到敵人 新增敵人到清除列表中");
                foreach (var enemy in enemyList.ToList())
                {
                    if (ReferenceEquals(enemy, other.transform))
                    {
                        enemyList.Remove(enemy);
                    }
                }
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
            var shootTransformPosition = _shootTransform.position;
            var weaponSettingPrefab = weaponSo.weaponSetting.prefab;
            GameObject weaponInstantiate = GetWeaponFromPool();
            if (weaponInstantiate == null)
            {
                weaponInstantiate = Instantiate(weaponSettingPrefab, shootTransformPosition,
                    Quaternion.identity, _weaponPool);
                weaponInstantiate.AddComponent<WeaponController>();
            }
            // 設置物件的位置和旋轉
            weaponInstantiate.GetComponent<SpriteRenderer>().sprite = weaponSo.weaponSetting.sprite;
            weaponInstantiate.transform.position = shootTransformPosition;
            weaponInstantiate.transform.rotation = Quaternion.identity; // 你可以根據需要設置特定的旋轉

            weaponInstantiate.GetComponent<WeaponController>().Initialize(weaponSo, target);
        }

        private GameObject GetWeaponFromPool()
        {
            foreach (Transform weapon in _weaponPool)
            {
                if (!weapon.gameObject.activeInHierarchy) // 檢查物件是否關閉
                {
                    weapon.gameObject.SetActive(true); // 啟用物件
                    // 在這裡做額外的設定，如位置、旋轉等
                    return weapon.gameObject; // 返回這個物件
                }
            }

            // 如果沒有可用物件，返回 null 或考慮擴充池
            return null;
        }

        public void SetWeapon(WeaponSettingSo weaponSettingSo)
        {
            heroSetting.defenseMechanismSetting.weaponSettingSo = weaponSettingSo;
        }
    }
}