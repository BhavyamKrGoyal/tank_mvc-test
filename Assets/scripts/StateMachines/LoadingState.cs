using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class LoadingState : GameState
    {
        

        public LoadingState()
        {
                stateName=States.LoadingState;
               
                   
        }
        public override void OnStateExit()
        {

        }
        public override void OnStateEnter()
        {
             SceneManager.LoadScene("LoadingScene");
        }
        public override void Update()
        {



        }
    }
}