using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class LobbyState : GameState
    {
        public LobbyState()
        {
            stateName = States.GamePlayState;
           
        }
        public override void OnStateExit()
        {

        }
        public override void OnStateEnter()
        {
             SceneManager.LoadScene("MainMenu");
        }
        public override void Update()
        {



        }
    }
}