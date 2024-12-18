using System.Collections.Generic;
using NaughtyAttributes;
using TowerDefense.Script.EventCenter.EventMediator;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Script
{
    public class UserData : MonoBehaviour
    {
        public static UserData instance;
        [SerializeField] private GameDataSetting gameData;
        [SerializeField] public GameDataSetting gamingData;

        [SerializeField] private List<Skill.Skill> skillList;

        private void Awake()
        {
            instance = this;
            gamingData = gameData;
        }

        private void Update()
        {
            // 暫時測試用特殊功能
            if (Input.GetKeyDown(KeyCode.K))
            {
                MoneyEventMediator.MoneyEnemyDeathNotify(99, 99);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                gameData.bagWeaponData = new List<string> { "Stone Axe" };
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                MoneyEventMediator.MoneyEnemyDeathNotify(-99, -99);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                MoneyEventMediator.MoneyEnemyDeathNotify(-gameData.money, -gameData.loot);
            }
        }

        public GameDataSetting GetGameData()
        {
            return gameData;
        }

        [Button]
        public void SavePlayerPref()
        {
            PlayerPrefs.SetInt("hp", gamingData.hp);
            PlayerPrefs.SetInt("money", gamingData.money);
            PlayerPrefs.SetInt("loot", gamingData.loot);
            PlayerPrefs.SetInt("progress", gamingData.progress);
            PlayerPrefs.SetInt("maxExperience", gamingData.maxExperience);
            PlayerPrefs.SetInt("experience", gamingData.experience);

            PlayerPrefs.SetString("experience", gamingData.bagWeaponData.ToString());
            Debug.Log($"gamingData.bagWeaponData.ToString():{gamingData.bagWeaponData.ToString()}");
        }

        [Button]
        void ClearPlayerPref()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}