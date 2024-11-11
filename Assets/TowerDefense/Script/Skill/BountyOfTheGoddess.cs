using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "BountyOfTheGoddess", menuName = "Skills/BountyOfTheGoddess")]
    public class BountyOfTheGoddess : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"經驗與錢幣獲取量增加5%");
        }
    }
}
