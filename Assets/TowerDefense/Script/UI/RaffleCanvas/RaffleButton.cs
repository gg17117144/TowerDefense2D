using DG.Tweening;
using NaughtyAttributes;
using TowerDefense.Script.EventCenter.EventMediator;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.RaffleCanvas
{
    public class RaffleButton : MonoBehaviour
    {
        [SerializeField] private Button singleSummonButton;
        [SerializeField] private Button bulkSummonButton;
        [SerializeField] private Button trustYouSelfButton;
        [SerializeField] private Button backButton;

        [SerializeField] private RaffleDataController raffleDataController;

        private void Start()
        {
            StartLoopAnimation();
            SetButtonFunction();
        }

        void StartLoopAnimation()
        {
            singleSummonButton.transform.DOScale(0.9f, 0.5f).SetLoops(-1, LoopType.Yoyo); // 無限循環
            bulkSummonButton.transform.DOScale(0.9f, 0.5f).SetLoops(-1, LoopType.Yoyo); // 無限循環
            trustYouSelfButton.transform.DOScale(0.9f, 0.5f).SetLoops(-1, LoopType.Yoyo); // 無限循環
        }

        void SetButtonFunction()
        {
            singleSummonButton.onClick.AddListener(DoGacha1Time);
            bulkSummonButton.onClick.AddListener(DoGacha10Time);
            trustYouSelfButton.onClick.AddListener(DoGachaTrustYouSelf);
            backButton.onClick.AddListener(CloseTheRaffleCanvas);
        }

        void DoGacha1Time()
        {
            if (UserData.instance.gamingData.loot >= 100)
            {
                Debug.Log($"扭蛋一次");
                MoneyEventMediator.DoGachaConsumeLoot(-100);
                raffleDataController.DoGacha1Time();
            }
            else
            {
                Debug.Log($"Loot不夠");
            }
        }

        void DoGacha10Time()
        {
            if (UserData.instance.gamingData.loot >= 1000)
            {
                Debug.Log($"扭蛋十次");
                MoneyEventMediator.DoGachaConsumeLoot(-1000);
                raffleDataController.DoGacha10Time();
            }
            else
            {
                Debug.Log($"Loot不夠");
            }
        }

        void DoGachaTrustYouSelf()
        {
            if (UserData.instance.gamingData.loot >= 100)
            {
                Debug.Log($"扭蛋相信自己一次");
                MoneyEventMediator.DoGachaConsumeLoot(-100);
                raffleDataController.DoGacha1Time();
            }
            else
            {
                Debug.Log($"Loot不夠");
            }
        }

        [Button]
        void CloseTheRaffleCanvas()
        {
            transform.parent.GetComponent<RaffleUIController>().CloseRaffleUI();
        }
    }
}