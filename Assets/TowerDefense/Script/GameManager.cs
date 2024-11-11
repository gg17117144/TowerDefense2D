using UnityEngine;
using UnityHFSM;

namespace TowerDefense.Script
{
    public class GameManager : MonoBehaviour
    {
        private StateMachine _fsm;

        //TODO 狀態機去觸發事件
        public static GameManager instance;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Initialize()
        {
            _fsm = new StateMachine();
            _fsm.AddState("Defense", onLogic: state => Defense());
            _fsm.AddState("LevelUp", onLogic: state => LevelUp());
            _fsm.AddState("Dead", onLogic: state => Dead());
            _fsm.SetStartState("Defense");
            _fsm.Init();
        }

        private void Start()
        {
            Initialize();
        }

        private void Defense()
        {
        }

        private void Dead()
        {
        }

        private void LevelUp()
        {
        }
    }
}