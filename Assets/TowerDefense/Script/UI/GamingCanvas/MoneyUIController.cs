using TMPro;
using TowerDefense.Script.EventCenter.UIEventCenter;
using UnityEngine;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class MoneyUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI lootBar;

        private void Initialize()
        {
            ChangeCoinTextValue(UserData.Instance.gamingData.money);
            ChangeLootTextValue(UserData.Instance.gamingData.loot);

            MoneyEventCenter.AddListener(MoneyEventType.AddMoney, ChangeCoinTextValue);
            MoneyEventCenter.AddListener(MoneyEventType.AddLoot, ChangeLootTextValue);
        }

        private void Start()
        {
            Initialize();
        }

        public void ChangeCoinTextValue(int value)
        {
            // coinText.text = $"{value}";
            coinText.text = value.ToString();
        }

        public void ChangeLootTextValue(int value)
        {
            // lootBar.text = $"{value}";
            lootBar.text = value.ToString();
        }
    }
}