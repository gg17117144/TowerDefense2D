using System;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TowerDefense.Script.UI.RaffleCanvas
{
    public class RaffleAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject group;
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject weaponCan;
        [SerializeField] private List<WeaponSettingSo> weaponSettingSoList;

        [Button]
        private void Start()
        {
            weaponCan.transform.DOShakeRotation(5f, 20, 5, 90).SetLoops(-1,LoopType.Yoyo);
        }

        [Button]
        public void Raffle()
        {
            Debug.Log("抽獎一次");
            var range = Random.Range(0,weaponSettingSoList.Count);
            prefab.GetComponent<Image>().sprite = weaponSettingSoList[range].weaponSetting.icon;
            var instantiate = Instantiate(prefab,group.transform);
            instantiate.transform.DOScale(1, 0.5f);
        }
        
        [Button]
        public void ClearGroup()
        {
            for (int i = 0; i < group.transform.childCount; i++)
            {
                var child = group.transform.GetChild(i);
                Destroy(child.gameObject);
            }
        }
    }
}
