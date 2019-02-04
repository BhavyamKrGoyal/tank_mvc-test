using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceUI : Singleton<ServiceUI>
{
    //For Changing Between Different UI Screens and any actions to be performed by the UI like Button Press

    ControllerMenuUI menu;
    ControllerStartUI start;
    ControllerPlayer playerController;
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            start = new ControllerStartUI();
            menu = new ControllerMenuUI();
        }
        else
        {
            start = null;
            menu = null;
        }
    }
    void Start()
    {
        //Set The Menu UI ie: play Button
        
    }
    public void StartGame()
    {
        menu.DestroyUI();
        start.DisplayUI();
    }
    public void updateUI(int health,int score)
    {
        start.UpdateHealth(health);
        start.UpdateScore(score);
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
