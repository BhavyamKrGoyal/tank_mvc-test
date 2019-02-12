using Replay_Service;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class GamePlayState : GameState
    {
        ControllerStartUI start;

        public GamePlayState()
        {
          
        }
        public override void OnStateExit()
        {
            start.DestroyUI();
            ServiceUI.Instance.SetCurrentUI(null);

        }
        public override void OnStateEnter()
        {
            if (SceneManager.GetActiveScene().name != "GameScene")
            {
                SceneManager.LoadScene("GameScene");
            }else{
                Update();
            }
        }

        public override void Update()
        {
            start = new ControllerStartUI();
            ServiceUI.Instance.SetCurrentUI(start);
            //start.DisplayUI();
           
        }
    }
}