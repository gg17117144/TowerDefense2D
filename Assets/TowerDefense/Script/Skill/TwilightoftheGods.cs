using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "TwilightoftheGods", menuName = "Skills/TwilightoftheGods")]
    public class TwilightoftheGods : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"眾神殞落 神給予的效果全數消失");
        }
    }
}
