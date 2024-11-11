using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "TwilightOfTheGods", menuName = "Skills/TwilightOfTheGods")]
    public class TwilightOfTheGods : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"眾神殞落 神給予的效果全數消失");
        }
    }
}
