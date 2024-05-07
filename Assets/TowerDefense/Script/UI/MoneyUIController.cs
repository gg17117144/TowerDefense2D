using TMPro;
using UnityEngine;

namespace TowerDefense.Script.UI
{
    public class MoneyUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI lootBar;

        private void Initialize()
        {
            ChangeCoinTextValue(0);
            ChangeLootTextValue(0);
        }

        private void Start()
        {
            Initialize();
        }

        public void ChangeCoinTextValue(float value)
        {
            coinText.text = $"{value}";
        }

        public void ChangeLootTextValue(int value)
        {
            lootBar.text = $"{value}";
        }
    }
}