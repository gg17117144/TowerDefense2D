using UnityEngine;

namespace TowerDefense.Script
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
