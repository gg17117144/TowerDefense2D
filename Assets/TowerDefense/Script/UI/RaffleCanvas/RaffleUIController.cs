using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace TowerDefense.Script.UI.RaffleCanvas
{
    public class RaffleUIController : MonoBehaviour
    {
        [SerializeField] private Transform gachaButtonPos;
        [SerializeField] private Transform midPos;

        private void Initialize()
        {
            transform.DOScale(0, 0);
            transform.DOMove(gachaButtonPos.position, 0).OnComplete(() => gameObject.SetActive(false));;
        }

        private void Start()
        {
            Initialize();
        }

        [Button]
        public void OpenRaffleUI()
        {
            gameObject.SetActive(true);
            transform.DOScale(1, 0.5f);
            transform.DOMove(midPos.position, 0.5f);
        }

        [Button]
        public void CloseRaffleUI()
        {
            transform.DOScale(0, 0.5f);
            transform.DOMove(gachaButtonPos.position, 0.5f).OnComplete(() => gameObject.SetActive(false));
        }
    }
}