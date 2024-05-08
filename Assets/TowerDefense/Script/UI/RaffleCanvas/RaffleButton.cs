using System;
using DG.Tweening;
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
        [SerializeField] private Button BackButton;

        private void Start()
        {
            singleSummonButton.transform.DOScale(0.9f, 0.5f).SetLoops(-1, LoopType.Yoyo); // 無限循環
            bulkSummonButton.transform.DOScale(0.9f, 0.5f).SetLoops(-1, LoopType.Yoyo); // 無限循環
            trustYouSelfButton.transform.DOScale(0.9f, 0.5f).SetLoops(-1, LoopType.Yoyo); // 無限循環
        }
    }
}