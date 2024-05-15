using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "Blizzard", menuName = "Skills/Blizzard")]
    public class Blizzard : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"敵方移動速度降低5%");
        }
    }
}
