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

        private List<string> _getWeaponName = new List<string>();
        private List<Sprite> _getWeaponIcon = new List<Sprite>();

        private void Start()
        {
            weaponSettingSoList = AllGameData.instance.allWeaponSettings;
        }

        [Button]
        public void DoGacha1Time()
        {
            // var range = Random.Range(0, weaponSettingSoList.Count);
            var doProbability = DoProbability(100);
            var weaponSettingIcon = weaponSettingSoList[doProbability].weaponSetting.icon;
            raffleAnimation.Raffle(weaponSettingIcon);
            WeaponEventMediator.DoGachaGetWeapon(weaponSettingSoList[doProbability].weaponSetting.name);
        }


        [Button]
        public void DoGacha10Time()
        {
            StartCoroutine(nameof(StartDoGacha10Time));
        }

        IEnumerator StartDoGacha10Time()
        {
            _getWeaponName = new List<string>();
            _getWeaponIcon = new List<Sprite>();
            for (int i = 0; i < 10; i++)
            {
                // var range = Random.Range(0, weaponSettingSoList.Count);
                int doProbability;
                if (i <= 8)
                {
                    doProbability = DoProbability(100);
                }
                else
                {
                    doProbability = DoProbability(40);
                    Debug.Log($"doProbability:{doProbability}");
                }
                
                var weaponSettingIcon = weaponSettingSoList[doProbability].weaponSetting.icon;
                _getWeaponIcon.Add(weaponSettingIcon);
                _getWeaponName.Add(weaponSettingSoList[doProbability].weaponSetting.name);
                WeaponEventMediator.DoGachaGetWeapon(weaponSettingSoList[doProbability].weaponSetting.name);
            }

            for (int i = 0; i < _getWeaponIcon.Count; i++)
            {
                raffleAnimation.Raffle(_getWeaponIcon[i]);
                yield return new WaitForSeconds(0.5f);
            }
        }

        public void ClearWeaponIconList()
        {
            _getWeaponIcon = new List<Sprite>();
        }

        private int DoProbability(int maxNum)
        {
            //TODO 需要修正機率的算法
            var range = Random.Range(0, maxNum);
            if (range <= 1)
            {
                var rangeNum = Random.Range(12, 15);
                return rangeNum;
            }
            else if (range <= 6)
            {
                var rangeNum = Random.Range(8, 12);
                return rangeNum;
            }
            else if (range <= 40)
            {
                var rangeNum = Random.Range(4, 8);
                return rangeNum;
            }
            else
            {
                var rangeNum = Random.Range(0, 4);
                return rangeNum;
            }
        }
    }
}