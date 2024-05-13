using System;
using UnityEngine;

namespace TowerDefense.Script
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
