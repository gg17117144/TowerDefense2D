using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "FireTrickeryChaos", menuName = "Skills/FireTrickeryChaos")]
    public class FireTrickeryChaos : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"每10坡各項效果隨機增減3%");
        }
    }
}
