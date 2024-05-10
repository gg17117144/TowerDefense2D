using DG.Tweening;
using TowerDefense.Script.EventCenter;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Script.UI
{
    public class ExperienceUIController : MonoBehaviour
    {
        [SerializeField] private Image experienceBar;

        private void Initialize()
        {
            ChangeExperienceBarValue(0);
            
            ExperienceEventCenter.AddListener(ExperienceEventType.UpdataExperience,ChangeExperienceBarValue);
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
    }
}