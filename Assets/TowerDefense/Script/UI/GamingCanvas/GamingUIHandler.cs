using System;
using NaughtyAttributes;
using TowerDefense.Script.UI.GamingCanvas;
using UnityEngine;

namespace TowerDefense.Script.UI
{
    public class GamingUIHandler : MonoBehaviour
    {
        public HpUIController HpUIController => hpUIController;
        [SerializeField] [Required] private HpUIController hpUIController;

        public ProgressUIController ProgressUIController => progressUIController;
        [SerializeField] [Required] private ProgressUIController progressUIController;

        public MoneyUIController MoneyUIController => moneyUIController;
        [SerializeField] [Required] private MoneyUIController moneyUIController;

        public ExperienceUIController ExperienceUIController => experienceUIController;
        [SerializeField] [Required] private ExperienceUIController experienceUIController;
        
    }
}