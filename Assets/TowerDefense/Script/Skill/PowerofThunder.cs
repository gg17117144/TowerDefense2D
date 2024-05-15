using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "PowerofThunder", menuName = "Skills/PowerofThunder")]
    public class PowerofThunder : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"傷害提升5% [持有妙爾尼爾則提升10%]");
        }
    }
}
