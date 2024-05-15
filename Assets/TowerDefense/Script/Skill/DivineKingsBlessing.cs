using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "DivineKingsBlessing", menuName = "Skills/DivineKingsBlessing")]
    public class DivineKingsBlessing : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"眾神給予的效果翻倍");
        }
    }
}
