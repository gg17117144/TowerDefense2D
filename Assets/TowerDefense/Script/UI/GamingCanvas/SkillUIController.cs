using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class SkillUIController : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject group;
        [SerializeField] private List<Skill.Skill> skillList;

        [SerializeField, ReadOnly] private int _canChooseSkillNum = 0;
        [SerializeField, ReadOnly] private bool _isChooseSkill = false;

        private void Initialize()
        {
            skillList = AllGameData.instance.allSkillSettings;
        }

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            if (_canChooseSkillNum >= 1)
            {
                if (_isChooseSkill == false)
                {
                    StartCoroutine(nameof(StartInstantiateSkill));
                }
            }
        }

        [Button]
        public void InstantiateSkill()
        {
            _canChooseSkillNum++;
            if (_canChooseSkillNum == 1)
            {
                StartCoroutine(nameof(StartInstantiateSkill));
            }
        }

        IEnumerator StartInstantiateSkill()
        {
            _isChooseSkill = true;
            group.SetActive(true);
            group.transform.localScale = Vector3.one;
            group.GetComponent<Image>().DOFade(0, 0);
            group.GetComponent<Image>().DOFade(1, 0.5f);
            for (int i = 0; i < 3; i++)
            {
                var instantiate = Instantiate(prefab, group.transform);
                RandomSetPrefabData(instantiate.GetComponent<Button>());
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void RandomSetPrefabData(Button button)
        {
            var range = Random.Range(0, skillList.Count);
            button.image.sprite = skillList[range].skillIcon;
            button.onClick.AddListener(skillList[range].ActivateSkill);
            button.onClick.AddListener(ClearGroup);
            button.transform.localScale = Vector3.zero;
            button.transform.DOScale(1, 0.5f);
        }


        [Button]
        private void ClearGroup()
        {
            _canChooseSkillNum--;
            for (int i = 0; i < group.transform.childCount; i++)
            {
                var child = group.transform.GetChild(i);
                child.GetComponent<Button>().onClick.RemoveAllListeners();
            }

            StartCoroutine(nameof(StartClearGroup));
        }

        IEnumerator StartClearGroup()
        {
            for (int i = 0; i < group.transform.childCount; i++)
            {
                var child = group.transform.GetChild(i);
                child.transform.DOScale(0, 0.5f);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(0.7f);
            for (int i = 0; i < group.transform.childCount; i++)
            {
                var child = group.transform.GetChild(i);
                Destroy(child.gameObject);
            }

            group.transform.localScale = Vector3.one;
            //TODO 這裡需要更新實現邏輯
            if (_canChooseSkillNum <= 0)
            {
                group.GetComponent<Image>().DOFade(0, 0.3f).OnComplete(() => group.SetActive(false));
            }
            _isChooseSkill = false;
        }
    }
}