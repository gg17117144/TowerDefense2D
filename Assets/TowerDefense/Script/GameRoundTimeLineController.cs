using TowerDefense.Script.EventCenter.EventMediator;
using TowerDefense.Script.ScriptObject.Script;
using UnityEngine;
using UnityEngine.Playables;

namespace TowerDefense.Script
{
    public class GameRoundTimeLineController : MonoBehaviour
    {
        [SerializeField] private PlayableDirector shipStart;

        private void OnEnable()
        {
            RoundEventMediator.OnStartRound += PlayerTimeLine01;
        }

        private void OnDestroy()
        {
            RoundEventMediator.OnStartRound -= PlayerTimeLine01;
        }

        private void PlayerTimeLine01(GameRoundData gameRoundData)
        {
            shipStart.Play();
            shipStart.stopped += OnTimelineStopped;

            void OnTimelineStopped(PlayableDirector playableDirector)
            {
                // 取消訂閱
                shipStart.stopped -= OnTimelineStopped;
                // 執行所需的邏輯
                RoundEventMediator.DoStartCreateEnemy(gameRoundData);
            }
        }
    }
}