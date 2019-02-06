using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class GameOverState : GameState
    {
        public GameOverState()
        {
            stateName = States.GameOverState;
        }
        public override void OnStateExit()
        {

        }
        public override void OnStateEnter()
        {
             SceneManager.LoadScene("GameOver");
        }
        public override void Update()
        {



        }
    }
}