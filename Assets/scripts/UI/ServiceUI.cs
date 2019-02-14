using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using StateMachines;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UI;

public class ServiceUI : Singleton<ServiceUI>
{
    //For Changing Between Different UI Screens and any actions to be performed by the UI like Button Press

    public GameObject startUI;
    public ControllerGamePlayUI GameUI;
    public RectTransform startUIParent;
    public Dictionary<PlayerNumber, ControllerStartUI> playerUI = new Dictionary<PlayerNumber, ControllerStartUI>();

    void Start()
    {
        GameApplication.Instance.OnPlayerSpawn += AddPlayerListener;
        //Set The Menu UI ie: play Button
        StateManager.Instance.OnStateChanged += GameStateChanged;
    }
    public void DestroyStartUI(){
        GameUI.DestroyUI();

    }
    
    public void DisplayStartUI(){
        if(GameUI==null){
            GameUI=new ControllerGamePlayUI();
       }else{
           GameUI.DisplayUI();
       }
    }
    public void SetStartUI(PlayerNumber playerNumber)
    {
        //ControllerStartUI start=new ControllerStartUI(startUI,startUIParent);
        playerUI.Add(playerNumber, new ControllerStartUI(startUI,startUIParent));
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
        if(scene.name=="GameScene"){
            startUIParent=GameObject.FindObjectOfType<HorizontalLayoutGroup>().gameObject.GetComponent<RectTransform>();
        }else{
            GameUI=null;
        }
    }

    public void GameStateChanged(GameState currentState)
    {
    }
    public void updateUI(PlayerData playerData)
    {
        if (playerUI[playerData.player.GetPlayerNumber()] != null)
        {
            playerUI[playerData.player.GetPlayerNumber()].UpdateHealth(playerData.health);
            playerUI[playerData.player.GetPlayerNumber()].UpdateScore(playerData.score);
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
        player.OnPlayerDeath+=OnPlayerDead;
        SetStartUI(player.GetPlayerNumber());
    }
    public void OnPlayerDead(ControllerPlayer player,InputComponent component,Controls controls){
        playerUI[player.GetPlayerNumber()].DestroyUI();
        playerUI.Remove(player.GetPlayerNumber());
    }
}
