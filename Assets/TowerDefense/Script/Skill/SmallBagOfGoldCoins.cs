using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "SmallBagOfGoldCoins", menuName = "Skills/SmallBagOfGoldCoins")]
    public class SmallBagOfGoldCoins : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"獲取3%額外金幣");
        }
    }
}
