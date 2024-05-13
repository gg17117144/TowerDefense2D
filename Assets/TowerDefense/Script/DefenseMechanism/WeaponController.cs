using System;
using DG.Tweening;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;

namespace TowerDefense.Script.DefenseMechanism
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private WeaponSettingSo setting;
        [SerializeField] private Transform target;
        [SerializeField] private float speed;

        public int DamageAmount => damageAmount;
        [SerializeField] private int damageAmount;

        public void Initialize(WeaponSettingSo weaponSo, Transform targetTransform)
        {
            setting = weaponSo;
            target = targetTransform;
            speed = setting.weaponSetting.speed;
            damageAmount = setting.weaponSetting.damage;
        }

        private void Start()
        {
            if (setting.weaponSetting.weaponType == WeaponType.Rotate)
            {
                // Debug.Log("應該有要旋轉");
                transform.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.WorldAxisAdd)
                    .SetLoops(-1, LoopType.Incremental);
            }
        }

        private void Update()
        {
            if (!ReferenceEquals(target, null))
            {
                ChaseEnemy();
            }
            else
            {
                DestroyObject();
            }
        }

        public void SettingWeapon(WeaponSettingSo weaponSettingSoSetting)
        {
            setting = weaponSettingSoSetting;
            ShotWeapon();
        }

        private void ShotWeapon()
        {
            Invoke(nameof(DestroyObject), 5f);
        }

        void ChaseEnemy()
        {
            // TODO 往敵人的方向前進
            try
            {
                if (!ReferenceEquals(target, null))
                {
                    // 計算距離
                    Vector3 thisPosition = transform.position;
                    Vector3 targetPosition = target.transform.position + new Vector3(0, 0.7f, 0);
                    Debug.DrawLine(thisPosition, targetPosition, Color.red);
                    // 計算怪物要移動的方向
                    Vector3 moveDirection = (targetPosition - thisPosition).normalized;

                    // 旋轉
                    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                    if (setting.weaponSetting.weaponType == WeaponType.NotRotate)
                    {
                        // Debug.Log("應該不會旋轉");
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                    }

                    // 移動
                    transform.position =
                        Vector3.MoveTowards(thisPosition, thisPosition + moveDirection, speed * Time.deltaTime);
                }
            }
            catch (Exception)
            {
                DestroyObject();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                DestroyObject();
            }
        }

        private void DestroyObject()
        {
            //TODO 需要更改成物件池的作法
            Destroy(gameObject);
        }
    }
}