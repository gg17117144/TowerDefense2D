using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class BuildingLevelUpController : MonoBehaviour
    {
        [SerializeField] private GameObject group;

        [SerializeField] private Button towerButton;
        [SerializeField] private Button wallButton;
        [SerializeField] private Button barrierButton;
        [SerializeField] private Button backButton;
        [SerializeField] private Button tempButton;

        private void Initialize()
        {
            towerButton.onClick.AddListener(LevelUpTower);
            wallButton.onClick.AddListener(LevelUpWall);
            barrierButton.onClick.AddListener(LevelUpBarrier);

            backButton.onClick.AddListener(CloseBuildingLevelUpPage);
            tempButton.onClick.AddListener(OpenBuildingLevelUpPage);
        }

        private void Start()
        {
            Initialize();
        }

        void LevelUpTower()
        {
            Debug.Log("升級建塔");
            CloseBuildingLevelUpPage();
        }

        void LevelUpWall()
        {
            Debug.Log("升級建塔");
            CloseBuildingLevelUpPage();
        }

        void LevelUpBarrier()
        {
            Debug.Log("升級建塔");
            CloseBuildingLevelUpPage();
        }

        [Button]
        void OpenBuildingLevelUpPage()
        {
            group.SetActive(true);
            group.transform.DOScale(1, 0.5f);
        }

        [Button]
        void CloseBuildingLevelUpPage()
        {
            group.transform.DOScale(0, 0.5f).OnComplete(() => group.SetActive(false));
        }
    }
}