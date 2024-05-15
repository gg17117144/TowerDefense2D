using UnityEngine;

namespace TowerDefense.Script.Skill
{
    [CreateAssetMenu(fileName = "BagOfGoldCoins", menuName = "Skills/BagOfGoldCoins")]
    public class BagOfGoldCoins : Skill
    {
        public override void ActivateSkill()
        {
            Debug.Log($"獲取5%額外金幣");
        }
    }
}