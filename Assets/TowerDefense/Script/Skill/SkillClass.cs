using UnityEngine;

namespace TowerDefense.Script.Skill
{
    public abstract class Skill : ScriptableObject
    {
        public Sprite skillIcon;

        public abstract void ActivateSkill();
        
        // TODO 自動抓取需要的icon
    }
}