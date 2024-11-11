using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "PowerOfThunder", menuName = "Skills/PowerOfThunder")]
    public class PowerOfThunder : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"傷害提升5% [持有妙爾尼爾則提升10%]");
        }
    }
}
