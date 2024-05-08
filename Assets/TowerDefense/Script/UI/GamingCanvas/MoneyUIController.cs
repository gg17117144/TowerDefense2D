using TMPro;
using TowerDefense.Script.EventCenter;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;

namespace TowerDefense.Script.UI
{
    public class MoneyUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI lootBar;

        private void Initialize()
        {
            ChangeCoinTextValue(GameDataSetting.Money);
            ChangeLootTextValue(GameDataSetting.Loop);

            MoneyEventCenter.AddListener(MoneyEventType.AddMoney, ChangeCoinTextValue);
            MoneyEventCenter.AddListener(MoneyEventType.AddLoop, ChangeLootTextValue);
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