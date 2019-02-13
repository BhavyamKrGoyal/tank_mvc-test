using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.UI;

public class ViewMenuUI : MonoBehaviour
{
    public Button play;

    public void Start()
    {
        //play = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();   
    }
    public void updateUI()
    {
       
        if ((StateManager.Instance.previousState is GameReplayState))
        {
             StateManager.Instance.ChangeState(new GameReplayState(), false);
        }else{
            StateManager.Instance.ChangeState(new GamePlayState(), false);
        }
        //Debug.Log(StateManager.Instance.previousState+" "+StateManager.Instance.currentState);
       
    }
    public void DestroyUI()
    {
        play.gameObject.SetActive(false);
    }
    public void DisplayUI()
    {
        play.gameObject.SetActive(true);
    }
}
