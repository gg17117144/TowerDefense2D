using NaughtyAttributes;
using TowerDefense.Script.UI;
using UnityEngine;

namespace TowerDefense.Script.TestScript
{
    public class TestGamingUIHandler : MonoBehaviour
    {
        [SerializeField] private GamingUIHandler gamingUIHandler;

        [BoxGroup("血量 預設滿血為100")] 
        [SerializeField] private int hpValue = 100;
        
        [Button]
        void TestHpUIController()
        {
            gamingUIHandler.HpUIController.ChangeHpText(hpValue);
            // ReSharper disable once PossibleLossOfFraction
            gamingUIHandler.HpUIController.ChangeHpBarValue(hpValue / 100f);
        }
        
        [BoxGroup("進度條")] 
        [SerializeField] private int progressTextValue;
        [BoxGroup("進度條 0~1")] 
        [SerializeField] private float progressBarValue;
        
        [Button]
        void TestProgressUIController()
        {
            gamingUIHandler.ProgressUIController.ChangeProgressText(progressTextValue);
            gamingUIHandler.ProgressUIController.ChangeProgressBarValue(progressBarValue);
        }
        
        [BoxGroup("金錢&擊殺數量")] 
        [SerializeField] private int coinValue;
        [BoxGroup("金錢&擊殺數量")] 
        [SerializeField] private int lootValue;
        
        [Button]
        void TestMoneyUIController()
        {
            gamingUIHandler.MoneyUIController.ChangeCoinTextValue(coinValue);
            gamingUIHandler.MoneyUIController.ChangeLootTextValue(lootValue);
        }
        
        [BoxGroup("經驗條 0~1")] 
        [SerializeField] private float experience;
        
        [Button]
        void TestExperienceUIController()
        {
            gamingUIHandler.ExperienceUIController.ChangeExperienceBarValue(experience);
        }
    }
}