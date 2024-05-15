using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.RaffleCanvas
{
    public class RaffleAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject group;
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject weaponCan;
        [SerializeField] private Button clearGroupButton;
        
        [Button]
        public void Raffle(Sprite icon)
        {
            Debug.Log("展示一張武器圖示");
            gameObject.SetActive(true);
            weaponCan.transform.DOShakeRotation(5f, 20, 5, 90).SetLoops(-1, LoopType.Yoyo);
            prefab.GetComponent<Image>().sprite = icon;
            var instantiate = Instantiate(prefab, group.transform);
            var raffleDataController = transform.parent.GetComponent<RaffleDataController>();
            instantiate.transform.DOScale(1, 0.5f).OnComplete((() => clearGroupButton.onClick.AddListener(raffleDataController.ClearWeaponIconList)));
            instantiate.transform.DOScale(1, 0.5f).OnComplete((() => clearGroupButton.onClick.AddListener(ClearGroup)));
            // TODO 應該換成10張都展示完畢再可跳過 或是call別的function是一次展示完畢10張抽獎的動畫 在切換Listener變成ClearGroup
        }

        [Button]
        public void ClearGroup()
        {
            for (int i = 0; i < group.transform.childCount; i++)
            {
                var child = group.transform.GetChild(i);
                Destroy(child.gameObject);
            }
            clearGroupButton.onClick.RemoveListener(ClearGroup);
            gameObject.SetActive(false);
        }
    }
}