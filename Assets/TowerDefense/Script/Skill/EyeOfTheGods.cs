using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "EyeOfTheGods", menuName = "Skills/EyeOfTheGods")]
    public class EyeOfTheGods : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"建塔增加射程20% & 傷害提高5%");
        }
    }
}
