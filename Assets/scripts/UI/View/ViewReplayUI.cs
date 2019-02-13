using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.UI;
namespace UI
{
    public class ViewReplayUI : MonoBehaviour
    {
        public Text replayText;
        public Button exit, pause;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void OnReplayExit()
        {
            StateManager.Instance.ChangeState(new GameOverState(), true);
        }
        public void DestroyUI()
        {

            pause.gameObject.SetActive(false);
            exit.gameObject.SetActive(false);
            replayText.gameObject.SetActive(false);
            pause.onClick.RemoveListener(OnReplayExit);
            exit.onClick.RemoveListener(OnReplayExit);
        }
        public void DisplayUI()
        {
            pause.onClick.AddListener(OnReplayPause);
            exit.onClick.AddListener(OnReplayExit);
            pause.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            replayText.gameObject.SetActive(true);
        }
        public void OnReplayPause()
        {
            if (!(StateManager.Instance.currentState is GamePauseState))
            {
                StateManager.Instance.ChangeState(new GamePauseState(), false);
            }
           // Debug.Log(StateManager.Instance.previousState + " " + StateManager.Instance.currentState);
        }
    }
}