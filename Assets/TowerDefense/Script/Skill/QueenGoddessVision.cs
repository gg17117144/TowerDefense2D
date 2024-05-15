using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "QueenGoddessVision", menuName = "Skills/QueenGoddessVision")]
    public class QueenGoddessVision : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"降低敵人數量 5% & 增加升級所需費用 10%");
        }
    }
}
