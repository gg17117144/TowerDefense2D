using System;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;

namespace TowerDefense.Script.DefenseMechanism
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private WeaponSettingSo setting;
        [SerializeField] private Transform target;

        [SerializeField] private Vector3 moveDirection;
        [SerializeField] private float speed;
        [SerializeField] private bool isShot = false;

        public void Initialize(WeaponSettingSo weaponSo, Transform targetTransform)
        {
            setting = weaponSo;
            target = targetTransform;
            speed = setting.weaponSetting.speed;
        }

        private void Start()
        {
            moveDirection = new Vector3(speed * Time.deltaTime, 0, 0);
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
            moveDirection = new Vector3(setting.weaponSetting.speed * Time.deltaTime, 0, 0);
            isShot = true;
        }

        void ChaseEnemy()
        {
            // TODO 往敵人的方向前進
            if (!ReferenceEquals(target, null))
            {

                // 計算距離
                Vector3 thisPosition = transform.position;
                Vector3 targetPosition = target.transform.position + new Vector3(0,0.7f,0);
                Debug.DrawLine(thisPosition,targetPosition,Color.red);
                // 計算怪物要移動的方向
                Vector3 moveDirection = (targetPosition - thisPosition).normalized;

                // 计算旋转角度
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

                // 设置旋转
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                // 移動怪物
                transform.position =
                    Vector3.MoveTowards(thisPosition, thisPosition + moveDirection, speed * Time.deltaTime);
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