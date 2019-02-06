using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class GamePlayState : GameState
    {
        public GamePlayState()
        {
            stateName = States.GamePlayState;

        }
        public override void OnStateExit()
        {

        }
        public override void OnStateEnter()
        {
            SceneManager.LoadScene("GameScene");
        }
        public override void Update()
        {



        }
    }
}