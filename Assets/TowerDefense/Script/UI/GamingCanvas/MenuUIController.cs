using NaughtyAttributes;
using TowerDefense.Script.UI.RaffleCanvas;
using UnityEngine;
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

        [SerializeField] private RaffleUIController raffleUIController;
        [SerializeField] private WeaponBagController weaponBagController;

        private void Initialize()
        {
            taskMenuButton.onClick.AddListener(OpenTaskMenu);
            weaponButton.onClick.AddListener(OpenWeapon);
            gachaButton.onClick.AddListener(OpenGacha);
            enemyMenuButton.onClick.AddListener(OpenEnemyMenu);
            settingButton.onClick.AddListener(OpenSetting);
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
            weaponBagController.OpenWeaponBag();
        }
    }
}