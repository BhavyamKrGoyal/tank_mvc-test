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
    public void updateUI() {
        StateManager.Instance.ChangeState(new GamePlayState(),true);
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
