using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "SmallBagofGoldCoins", menuName = "Skills/SmallBagofGoldCoins")]
    public class SmallBagofGoldCoins : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"獲取3%額外金幣");
        }
    }
}
