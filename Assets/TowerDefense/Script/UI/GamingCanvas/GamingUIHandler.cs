using System;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using TowerDefense.Script.UI.GamingCanvas;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI
{
    public class GamingUIHandler : MonoBehaviour
    {
        public static GamingUIHandler Instance;
        
        public HpUIController HpUIController => hpUIController;
        [SerializeField] [Required] private HpUIController hpUIController;

        public ProgressUIController ProgressUIController => progressUIController;
        [SerializeField] [Required] private ProgressUIController progressUIController;

        public MoneyUIController MoneyUIController => moneyUIController;
        [SerializeField] [Required] private MoneyUIController moneyUIController;

        public ExperienceUIController ExperienceUIController => experienceUIController;
        [SerializeField] [Required] private ExperienceUIController experienceUIController;

        private Image[] _imageList;
        private TextMeshProUGUI[] _textList;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _imageList = GetComponentsInChildren<Image>();
            _textList = GetComponentsInChildren<TextMeshProUGUI>();
        }

        [Button]
        public void OpenGamingUI()
        {
            foreach (Image image in _imageList)
            {
                image.DOFade(1, 1f);
            }
            foreach (TextMeshProUGUI text in _textList)
            {
                Debug.Log("打開text");
                text.gameObject.SetActive(true);
            }
        }
        
        [Button]
        public void CloseGamingUI()
        {
            foreach (Image image in _imageList)
            {
                image.DOFade(0, 1f);
            }
            foreach (TextMeshProUGUI text in _textList)
            {
                Debug.Log("關閉text");
                text.gameObject.SetActive(false);
            }
        }
    }
}