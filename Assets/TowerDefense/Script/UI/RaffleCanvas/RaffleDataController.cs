using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TowerDefense.Script.EventCenter;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;

namespace TowerDefense.Script.UI.RaffleCanvas
{
    public class RaffleDataController : MonoBehaviour
    {
        [SerializeField] private RaffleAnimation raffleAnimation;
        [SerializeField] private List<WeaponSettingSo> weaponSettingSoList;

        private void Start()
        {
            weaponSettingSoList = AllGameData.instance.allWeaponSettings;
        }

        [Button]
        public void DoGacha1Time()
        {
            var range = Random.Range(0, weaponSettingSoList.Count);
            var weaponSettingIcon = weaponSettingSoList[range].weaponSetting.icon;
            raffleAnimation.Raffle(weaponSettingIcon);
            WeaponEventMediator.DoGachaGetWeapon(weaponSettingSoList[range].weaponSetting.name);
        }


        [Button]
        public void DoGacha10Time()
        {
            StartCoroutine(nameof(StartDoGacha10Time));
        }

        IEnumerator StartDoGacha10Time()
        {
            for (int i = 0; i < 10; i++)
            {
                var range = Random.Range(0, weaponSettingSoList.Count);
                var weaponSettingIcon = weaponSettingSoList[range].weaponSetting.icon;
                raffleAnimation.Raffle(weaponSettingIcon);
                WeaponEventMediator.DoGachaGetWeapon(weaponSettingSoList[range].weaponSetting.name);

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}