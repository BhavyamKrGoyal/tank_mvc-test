using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceUI : Singleton<ServiceUI>
{
    //For Changing Between Different UI Screens and any actions to be performed by the UI like Button Press

    ControllerStartUI start;

    void Start()
    {
        GameApplication.Instance.OnPlayerSpawn += AddPlayerListener;
        //Set The Menu UI ie: play Button
        StateManager.Instance.OnStateChanged += GameStateChanged;
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
    }

    public void GameStateChanged(GameState currentState)
    {
        


    }
    public void StartGame()
    {

    }
    public void SetCurrentUI(ControllerStartUI start)
    {
        this.start = start;
    }
    public void updateUI(PlayerData playerData)
    {
        if (start != null)
        {
            start.UpdateHealth(playerData.health);
            start.UpdateScore(playerData.score);
            if (playerData.score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", playerData.score);
            }
        }
    }
    public void Replay()
    {
        StateManager.Instance.ChangeState(new GamePlayState(), true);
    }
    public void GameOver()
    {
        StateManager.Instance.ChangeState(new GameOverState(), true);
    }
    public void LoadMenu()
    {
        StateManager.Instance.ChangeState(new LobbyState(), false);
    }
    public void AddPlayerListener(ControllerPlayer player)
    {
        player.OnUIUpdate += updateUI;
    }
}
