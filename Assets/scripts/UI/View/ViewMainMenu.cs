using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ViewMainMenu:MonoBehaviour
{
    Button play;
    Text highScore;

    public void Start()
    {
        play = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();
        highScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        DisplayUI();
        highScore.text = "HighScore : " + PlayerPrefs.GetInt("HighScore", 0);

        

        
    }
    
    public void DestroyUI()
    {
        play.gameObject.SetActive(false);

    }
    public void DisplayUI()
    {
        play.gameObject.SetActive(true);
    }
    public void LoadGameScene()
    {
       
        StateManager.Instance.ChangeState(new GamePlayState(),true);
    }
}
