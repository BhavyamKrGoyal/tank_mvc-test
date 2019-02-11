using Replay_Service;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace StateMachines
{
    public class GameReplayState : GameState
    {
          public GameReplayState()
        {
           
        }
        public override void OnStateExit()
        {

        }
        public override void OnStateEnter()
        {
            ServiceReplay.Instance.SetQueue();
            GameApplication.Instance.ReSpawnPlayer2(Controls.WASD,PlayerNumber.Player1,ServiceReplay.Instance.playerPosition[PlayerNumber.Player1]);
            
        }
        public override void Update()
        {



        }
    }
}