using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceUI : Singleton<ServiceUI>
{
    //For Changing Between Different UI Screens and any actions to be performed by the UI like Button Press

    ControllerMenuUI menu;
    ControllerStartUI start;

    
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            start = new ControllerStartUI();
            menu = new ControllerMenuUI();
            GameApplication.Instance.OnPlayerSpawn += AddPlayerListener;
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
    public void updateUI(PlayerData playerData)
    {
        start.UpdateHealth(playerData.health);
        start.UpdateScore(playerData.score);
        if (playerData.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerData.score);
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
    public void AddPlayerListener(ControllerPlayer player)
    {
        player.OnUIUpdate += updateUI;
    }
}
