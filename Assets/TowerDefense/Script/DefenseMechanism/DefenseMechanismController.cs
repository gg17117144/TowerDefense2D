using System.Collections.Generic;
using System.Reflection;
using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerDefense.Script.DefenseMechanism
{
    public class DefenseMechanismController : MonoBehaviour
    {
        [SerializeField] private DefenseMechanismSettingSo setting;
        private Transform _weaponPool;
        [SerializeField] private List<Transform> enemyList = new List<Transform>();
        private float _stopTime = 0;

        [SerializeField] private Transform shootTransform;

        private void Start()
        {
            _weaponPool = GameObject.Find("WeaponPool").transform;
            shootTransform = transform.Find("shootTransform").transform;
        }

        private void Update()
        {
            _stopTime += Time.deltaTime;
            if (enemyList.Count >= 1 && _stopTime >= 1f)
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
            Track(target);
        }

        private void Track(Transform target)
        {
            var weaponSo = setting.defenseMechanismSetting.weaponSettingSo;
            var shootTransformPosition = shootTransform.position;

            var weaponSettingPrefab = weaponSo.weaponSetting.prefab;
            var weaponInstantiate = Instantiate(weaponSettingPrefab, shootTransformPosition,
                Quaternion.identity, _weaponPool);
            WeaponController weaponController = weaponInstantiate.AddComponent<WeaponController>();
            weaponController.Initialize(weaponSo, target);
        }

        private void notrack(Transform target)
        {
            // 計算生成武器的方向，使其朝向目標
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var quaternion = Quaternion.Euler(0, 0, angle);

            var weaponSo = setting.defenseMechanismSetting.weaponSettingSo;
            var shootTransformPosition = shootTransform.position;

            var weaponSettingPrefab = weaponSo.weaponSetting.prefab;
            var weaponInstantiate = Instantiate(weaponSettingPrefab, shootTransformPosition,
                Quaternion.identity, _weaponPool);
            weaponInstantiate.transform.rotation = quaternion;
        }
    }
}