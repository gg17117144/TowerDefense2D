using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI.GamingCanvas
{
    public class ExperienceUIController : MonoBehaviour
    {
        [SerializeField] private Image experienceBar;
        [SerializeField] private SkillUIController skillUIController;
        
        private void Initialize()
        {
            ChangeExperienceBarValue(UserData.Instance.gamingData.experience);

            // ExperienceEventCenter.AddListener(ExperienceEventType.UpdataExperience,ChangeExperienceBarValue);
            // ExperienceEventCenter.AddListener(ExperienceEventType.LeverUp,CallInstantiateSkill);
        }

        private void Start()
        {
            Initialize();
        }

        public void ChangeExperienceBarValue(float value)
        {
            experienceBar.DOKill();
            experienceBar.DOFillAmount(value, 0.5f);
        }

        public void CallInstantiateSkill(float value)
        {
            skillUIController.InstantiateSkill();
        }
    }
}