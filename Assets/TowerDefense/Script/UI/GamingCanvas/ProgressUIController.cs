using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI
{
    public class ProgressUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private Image progressBar;

        [SerializeField] private Transform handleRightPos;
        [SerializeField] private Transform handleLeftPos;
        [SerializeField] private Image progressHandle;

        [SerializeField] private int fakeTime = 1;
        private void Initialize()
        {
            ChangeProgressText(1);
            ChangeProgressBarValue(1);
        }

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            Invoke(nameof(StartWaves),7f);
        }

        public void StartWaves()
        {
            TempTime();
            InvokeRepeating(nameof(FakeTime), 60f, 60f);
        }

        void FakeTime()
        {
            progressBar.DOKill();
            progressHandle.transform.DOKill();
            fakeTime++;
            ChangeProgressText(fakeTime);
            progressBar.DOFillAmount(1, 0.5f);
            progressHandle.transform.DOMove(CalculatePos(1), 0.5f).OnComplete((() => TempTime()));
            GamingUIHandler.Instance.ExperienceUIController.CallInstantiateSkill(0);
        }

        void TempTime()
        {
            progressBar.DOFillAmount(0, 60f);
            progressHandle.transform.DOMove(CalculatePos(0), 60f);
        }

        public void ChangeProgressBarValue(float value)
        {
            progressBar.DOKill();
            progressHandle.DOKill();
            progressBar.DOFillAmount(value, 0.5f);
            progressHandle.transform.DOMove(CalculatePos(value), 0.5f);
        }

        public void ChangeProgressText(int value)
        {
            //TODO 看看是否要加入多國語系
            progressText.text = $"進攻波次：{value}";
        }

        private Vector3 CalculatePos(float value)
        {
            var position = handleLeftPos.position;
            var differenceX = handleRightPos.position.x - position.x;
            var currentLocation = (differenceX * value) + position.x;
            var transformPosition = progressHandle.transform.position;
            Vector3 currentLocationVector3 = new Vector3(currentLocation, transformPosition.y, transformPosition.z);
            return currentLocationVector3;
        }
    }
}