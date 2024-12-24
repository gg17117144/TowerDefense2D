using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.Serialization;
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
        [SerializeField] private Button backButton;

        private void Start()
        {
            backButton.onClick.AddListener(CloseWeaponBag);
            allWeaponSettingSoList = AllGameData.instance.allWeaponSettings;
        }

        private void ResetWeaponBagData()
        {
            var bagWeaponDatas = UserData.instance.gamingData.bagWeaponData;
            foreach (var bagWeaponData in bagWeaponDatas)
            {
                foreach (var allWeaponSetting in allWeaponSettingSoList)
                {
                    if (allWeaponSetting.name == bagWeaponData)
                    {
                        // Debug.Log($"生成背包中的武器:{allWeaponSetting.name}");
                        prefab.transform.GetComponent<Image>().sprite = allWeaponSetting.weaponSetting.icon;
                        var instantiate = Instantiate(prefab, content.transform);
                        instantiate.GetComponent<Button>().onClick.AddListener(() => SetHeroWeapon(allWeaponSetting));
                        instantiate.GetComponent<Button>().onClick.AddListener(CloseWeaponBag);
                        instantiate.transform.DOScale(1, 0.5f);
                    }
                }
            }
        }

        private void SetHeroWeapon(WeaponSettingSo weaponSettingSo)
        {
            Hero.Hero.instance.SetWeapon(weaponSettingSo);
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