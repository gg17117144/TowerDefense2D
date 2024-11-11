using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "ValorOfTheWarGod", menuName = "Skills/ValorOfTheWarGod")]
    public class ValorOfTheWarGod : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"傷害與功速上升5% & 敵人數量上升5% & 傷害下降3%");
        }
    }
}
