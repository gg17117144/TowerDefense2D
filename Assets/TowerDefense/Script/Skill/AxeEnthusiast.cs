using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "AxeEnthusiast", menuName = "Skills/AxeEnthusiast")]
    public class AxeEnthusiast : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"斧頭類武器傷害提升10% & 其他類武器傷害下降25%");
        }
    }
}