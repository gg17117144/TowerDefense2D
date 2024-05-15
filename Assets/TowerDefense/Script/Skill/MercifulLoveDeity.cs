using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "MercifulLoveDeity", menuName = "Skills/MercifulLoveDeity")]
    public class MercifulLoveDeity : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"傷害與攻速下降3% & 血量與恢復上升5%");
        }
    }
}
