using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class WeaponBagController : MonoBehaviour
    {
        [SerializeField] private GameObject content;
        [SerializeField] private GameObject prefab;
        [SerializeField] private List<WeaponSettingSo> allWeaponSettingSoList;

        [SerializeField] private Transform weaponBagButtonPos;
        [SerializeField] private Transform midPos;
        [SerializeField] private Transform bagBackGround;
        [SerializeField] private Button backBotton;

        private void Start()
        {
            backBotton.onClick.AddListener(CloseWeaponBag);
            allWeaponSettingSoList = AllGameData.instance.allWeaponSettings;
        }

        private void ResetWeaponBagData()
        {
            var bagWeaponDatas = GameData.instance.gamingData.bagWeaponData;
            foreach (var bagWeaponData in bagWeaponDatas)
            {
                foreach (var allWeaponSetting in allWeaponSettingSoList)
                {
                    if (allWeaponSetting.name.Contains(bagWeaponData))
                    {
                        Debug.Log($"生成背包中的武器:{allWeaponSetting.name}");
                        prefab.transform.GetComponent<Image>().sprite = allWeaponSetting.weaponSetting.icon;
                        var instantiate = Instantiate(prefab, content.transform);
                        instantiate.transform.DOScale(1, 0.5f);
                    }
                }
            }
        }

        private void GetWeaponSo()
        {
        }

        [Button]
        public void OpenWeaponBag()
        {
            ResetWeaponBagData();
            bagBackGround.gameObject.SetActive(true);
            bagBackGround.DOScale(1, 0.5f);
            bagBackGround.DOMove(midPos.position, 0.5f);
        }

        [Button]
        public void CloseWeaponBag()
        {
            bagBackGround.DOScale(0, 0.5f);
            bagBackGround.DOMove(weaponBagButtonPos.position, 0.5f)
                .OnComplete(() => bagBackGround.gameObject.SetActive(false)).OnComplete(() => Clearcontent());
        }

        [Button]
        public void Clearcontent()
        {
            for (int i = 0; i < content.transform.childCount; i++)
            {
                var child = content.transform.GetChild(i);
                Destroy(child.gameObject);
            }
        }
    }
}