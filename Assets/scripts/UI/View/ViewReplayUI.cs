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
        public Button exit;
        // Start is called before the first frame update
        void Start()
        {
            exit.onClick.AddListener(OnReplayExit);
        }
        public void OnReplayExit(){
            StateManager.Instance.ChangeState(new GameOverState(),true);
        }
        public void DestroyUI()
        {
            exit.gameObject.SetActive(false);
            replayText.gameObject.SetActive(false);
            exit.onClick.RemoveListener(OnReplayExit);

        }
        public void DisplayUI()
        {
            
            exit.gameObject.SetActive(true);
            replayText.gameObject.SetActive(true);

        }
    }
}