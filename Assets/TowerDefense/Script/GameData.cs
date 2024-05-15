using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TowerDefense.Script.EventCenter;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Script
{
    public class GameData : MonoBehaviour
    {
        public static GameData instance;
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
            if (Input.GetKeyDown(KeyCode.K))
            {
                MoneyEventMediator.MoneyEnemyDeathNotify(99,99);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                gameData.bagWeaponData = new List<string>();
                gameData.bagWeaponData.Add("Stone Axe");
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                MoneyEventMediator.MoneyEnemyDeathNotify(-99,-99);
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                MoneyEventMediator.MoneyEnemyDeathNotify(-gameData.money,-gameData.loot);
            }
        }

        public GameDataSetting GetgameData()
        {
            for (int i = 0; i < skillList.Count; i++)
            {

            }
            return gameData;
        }
        
        [Button]
        public void SavePlayerpref()
        {
            PlayerPrefs.SetInt("hp",gamingData.hp);
            PlayerPrefs.SetInt("money",gamingData.money);
            PlayerPrefs.SetInt("loot",gamingData.loot);
            PlayerPrefs.SetInt("progress",gamingData.progress);
            PlayerPrefs.SetInt("maxExperience",gamingData.maxExperience);
            PlayerPrefs.SetInt("experience",gamingData.experience);
            
            PlayerPrefs.SetString("experience",gamingData.bagWeaponData.ToString());
            Debug.Log($"gamingData.bagWeaponData.ToString():{gamingData.bagWeaponData.ToString()}");
        }

        [Button]
        void ClearPlayerpref()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}