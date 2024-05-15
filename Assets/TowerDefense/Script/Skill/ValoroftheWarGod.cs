using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "ValoroftheWarGod", menuName = "Skills/ValoroftheWarGod")]
    public class ValoroftheWarGod : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"傷害與功速上升5% & 敵人數量上升5% & 傷害下降3%");
        }
    }
}
