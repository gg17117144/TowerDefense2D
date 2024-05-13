using System.Collections.Generic;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;

namespace TowerDefense.Script.DefenseMechanism
{
    public class DefenseMechanismController : MonoBehaviour
    {
        [SerializeField] private DefenseMechanismSettingSo defenseMechanismSetting;
        [SerializeField] private List<Transform> enemyList = new List<Transform>();
        private Transform _weaponPool;
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
            if (enemyList.Count >= 1 &&
                _stopTime >= 1 / defenseMechanismSetting.defenseMechanismSetting.attackSpeed)
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
            var weaponSo = defenseMechanismSetting.defenseMechanismSetting.weaponSettingSo;
            var shootTransformPosition = shootTransform.position;

            var weaponSettingPrefab = weaponSo.weaponSetting.prefab;
            var weaponInstantiate = Instantiate(weaponSettingPrefab, shootTransformPosition,
                Quaternion.identity, _weaponPool);
            WeaponController weaponController = weaponInstantiate.AddComponent<WeaponController>();
            weaponController.Initialize(weaponSo, target);
        }
    }
}