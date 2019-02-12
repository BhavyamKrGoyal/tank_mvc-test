using Enemy;
using Replay_Service;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace StateMachines
{
    public class GameReplayState : GameState
    {
        ControllerReplayUI controller;
        public GameReplayState()
        {

        }
        public override void OnStateExit()
        {
            InputManager.Instance.ResetInput();
            controller.DestroyUI();
            controller = null;
        }
        public override void OnStateEnter()
        {
            controller = new ControllerReplayUI();
             controller.DisplayUI();
            if (!(StateManager.Instance.previousState is GamePauseState))
            {
                ServiceEnemy.Instance.RemoveAllEnemy();
                ServiceReplay.Instance.ReplaySpawn();
                ServiceReplay.Instance.SetQueue();
               
            }else{    
            }
        }
        public override void Update()
        {



        }
    }
}