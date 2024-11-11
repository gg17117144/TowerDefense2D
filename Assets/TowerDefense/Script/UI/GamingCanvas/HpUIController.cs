using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class HpUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private Image hpBar;

        private void Initialize()
        {
            ChangeHpBarValue(100);
            ChangeHpText(100);
        }

        private void Start()
        {
            Initialize();
        }

        public void ChangeHpBarValue(float value)
        {
            hpBar.DOKill();
            //TODO鑰更改最大血量
            hpBar.DOFillAmount(value, 0.5f);
        }

        public void ChangeHpText(int value)
        {
            //TODO 看看是否要加入多國語系
            hpText.text = $"{value}";
        }
    }
}