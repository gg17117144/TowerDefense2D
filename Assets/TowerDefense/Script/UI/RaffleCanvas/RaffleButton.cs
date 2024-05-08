using System;
using DG.Tweening;
using NaughtyAttributes;
using Unity.VisualScripting;
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
            backButton.onClick.AddListener(CloseTheRaffleCanvas);
        }

        [Button]
        void CloseTheRaffleCanvas()
        {
            transform.parent.GetComponent<RaffleUIController>().CloseRaffleUI();
        }
    }
}