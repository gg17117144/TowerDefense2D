using System;
using DG.Tweening;
using NaughtyAttributes;
using TowerDefense.Script.UI.RaffleCanvas;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class MenuUIController : MonoBehaviour
    {
        [SerializeField] private Button enemyMenuButton;
        [SerializeField] private Button gachaButton;
        [SerializeField] private Button taskMenuButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button weaponButton;

        [FormerlySerializedAs("raffleUIHandler")] [SerializeField] private RaffleUIController raffleUIController;
        private void Initialize()
        {
            enemyMenuButton.onClick.AddListener(OpenEnemyMenu);
            gachaButton.onClick.AddListener(OpenGacha);
            taskMenuButton.onClick.AddListener(OpenTaskMenu);
            settingButton.onClick.AddListener(OpenSetting);
            weaponButton.onClick.AddListener(OpenWeapon);
        }
        private void Start()
        {
            Initialize();
        }

        private void OpenEnemyMenu()
        {

        }
        
        [Button]
        private void OpenGacha()
        {
            raffleUIController.OpenRaffleUI();
        }
        
        private void OpenTaskMenu()
        {
            
        }
        
        private void OpenSetting()
        {
            
        }
        
        private void OpenWeapon()
        {
            
        }
        
    }
}