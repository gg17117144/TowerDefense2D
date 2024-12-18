using System;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using TowerDefense.Script.EventCenter.UIEventCenter;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class ProgressUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private Slider progressBar;

        [SerializeField] private int fakeTime = 1;
        [SerializeField] private int fakeRound = 1;

        private void Initialize()
        {
            ChangeProgressText(1);
            ChangeProgressBarValue(1);
        }

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            ProgressUIEventMediator.OnProgressChange += ChangeProgress;
        }

        private void OnDisable()
        {
            ProgressUIEventMediator.OnProgressChange -= ChangeProgress;
        }

        private void ChangeProgress(int roundValue, float roundTime)
        {
            ChangeProgressText(roundValue);
            ChangeProgressBarValue(roundTime);
        }

        private void ChangeProgressBarValue(float value)
        {
            // 計算目標值
            var targetValue = progressBar.maxValue - value;
            // 使用 DOValue 補間到目標值，設置動畫時間和緩動效果
            progressBar.DOValue(targetValue, 0.5f) // 0.5f 是動畫持續時間，可根據需要調整
                .SetEase(Ease.OutQuad); // 使用平滑的緩動效果（Ease.OutQuad）
        }

        private void ChangeProgressText(int value)
        {
            //TODO 看看是否要加入多國語系
            progressText.text = $"進攻波次：{value}";
        }
    }
}