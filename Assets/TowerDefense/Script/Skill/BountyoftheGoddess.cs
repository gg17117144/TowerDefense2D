using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "BountyoftheGoddess", menuName = "Skills/BountyoftheGoddess")]
    public class BountyoftheGoddess : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"經驗與錢幣獲取量增加5%");
        }
    }
}
