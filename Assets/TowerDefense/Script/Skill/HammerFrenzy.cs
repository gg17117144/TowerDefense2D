using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "HammerFrenzy", menuName = "Skills/HammerFrenzy")]
    public class HammerFrenzy : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"槌子類武器傷害提升10% &　其他類武器傷害下降25%");
        }
    }
}
