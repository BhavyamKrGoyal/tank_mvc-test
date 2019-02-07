using Interfaces;
using StateMachines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerPlayer : IBasePlayerController
{
    public Dictionary<PlayerStates, bool> currentStates = new Dictionary<PlayerStates, bool>();
    ViewPlayer view;
    float pauseTartedTime=0;
    ModelPlayer model;
    Dictionary<PlayerStates, List<PlayerStates>> StateGraph = new Dictionary<PlayerStates, List<PlayerStates>>();
    public PlayerData playerData;
    InputComponent inputComponent;
    public event Action<PlayerData> OnUIUpdate;
    public event Action<PlayerData> OnBulletShot;
    public event Action<PlayerData> OnEnemyKilled;
    public event Action<ControllerPlayer, InputComponent, Controls> OnPlayerDeath;
    public ControllerPlayer(GameObject player, Vector3 spawnPoint, Controls controls, PlayerNumber playerNumber, bool gameStarted)
    {
        currentStates.Add(PlayerStates.Move, false);
        currentStates.Add(PlayerStates.Regen, false);
        currentStates.Add(PlayerStates.Shoot, false);
        currentStates.Add(PlayerStates.paused, false);
        StateGraph.Add(PlayerStates.Move, new List<PlayerStates> { PlayerStates.paused, PlayerStates.Regen });
        StateGraph.Add(PlayerStates.Shoot, new List<PlayerStates> { PlayerStates.paused });
        StateGraph.Add(PlayerStates.Regen, new List<PlayerStates> { PlayerStates.paused, PlayerStates.Move });
        StateGraph.Add(PlayerStates.paused, new List<PlayerStates> { PlayerStates.Regen, PlayerStates.Move, PlayerStates.Shoot });
        this.view = GameObject.Instantiate(player, spawnPoint, Quaternion.identity, null).GetComponent<ViewPlayer>();
        this.model = new ModelPlayer(controls);
        view.SetController(this);
        model.playerNumber = playerNumber;
        model.gameStarted = gameStarted;
        inputComponent = new InputComponent(this);
        playerData.player = this;
        StateManager.Instance.OnStateChanged += GamePauseState;

    }
    public void GamePauseState(GameState currentState)
    {
        if (currentState is GamePauseState)
        {
            pauseTartedTime = Time.timeSinceLevelLoad;
            currentStates[PlayerStates.Move] = false;
            currentStates[PlayerStates.Regen] = false;
            currentStates[PlayerStates.Shoot] = false;
            currentStates[PlayerStates.paused] = true;
        }
        else
        {
            pauseTartedTime = Time.timeSinceLevelLoad - pauseTartedTime;
            currentStates[PlayerStates.paused] = false;
        }
    }
    public bool GetGameStarted()
    {
        return model.gameStarted;
    }
    public PlayerNumber GetPlayerNumber()
    {
        return model.playerNumber;
    }
    public Controls GetControls()
    {
        return model.controls;
    }
    public bool IsFreez()
    {
        return model.freez;
    }
    public void Update(float horizontal, float vertical)
    {
        if (!currentStates[PlayerStates.paused])
        {
            if (horizontal != 0 || vertical != 0)
            {
                Move(horizontal, vertical);
            }else{
                currentStates[PlayerStates.Regen] = true;
                if(model.health<100){
                model.TakeDamage(-0.1f);
                //Debug.Log(model.health);
                }
            }
        }
    }
    public void Move(float horizontal, float vertical)
    {

        //Debug.Log("controller");

        currentStates[PlayerStates.Move] = true;
        currentStates[PlayerStates.Regen] = false;
        view.MovePlayer(horizontal * model.rotationSpeed * Time.deltaTime, vertical * model.speed * Time.deltaTime * model.boost);

    }
    public void StartBoost()
    {
        model.boost = 2;
    }
    public void StopBoost()
    {
        model.boost = 1;
    }
    public void TankHit(int damage)
    {
        model.TakeDamage(damage);
        playerData.score = model.score;
        playerData.health = (int)model.health;
        playerData.achievementTypes = AchievementTypes.Score;
        OnUIUpdate.Invoke(playerData);
        if (!model.IsAlive())
        {
            DestroyObject();
        }
        //ServiceUI.Instance.updateUI(model.health, model.score);
    }
    public void EnemyKilled(int score)
    {
        UpdateScore(score);
        playerData.achievementTypes = AchievementTypes.EnemiesKilled;
        OnEnemyKilled?.Invoke(playerData);
    }
    private void UpdateScore(int score)
    {
        model.score = model.score + score;
        playerData.score = model.score;
        playerData.health = (int)model.health;
        playerData.progress = model.score;
        playerData.achievementTypes = AchievementTypes.Score;
        OnUIUpdate.Invoke(playerData);
        //ServiceUI.Instance.updateUI(model.health, model.score);
    }
    public void Shoot()
    {
       
        if (!currentStates[PlayerStates.paused])
        {
            if (model.lastShot + (model.fireInterval + pauseTartedTime) < Time.timeSinceLevelLoad)
            {
              
                pauseTartedTime = 0;
                model.lastShot = Time.timeSinceLevelLoad;
                playerData.achievementTypes = AchievementTypes.BulletsShot;
                playerData.progress = 1;
                ControllerBullet controllerBullet = ServiceBullet.Instance.MakeBullet(model.bulletType);
                OnBulletShot?.Invoke(playerData);
                controllerBullet.SetShooter(this);
                controllerBullet.Shoot(view.muzzle.transform);
            }
        }

    }
    public InputComponent GetInputComponent()
    {
        return inputComponent;
    }
    public void DestroyObject()
    {
        OnPlayerDeath.Invoke(this, inputComponent, GetControls());
        view.DestroyPlayer();

        //GameApplication.Instance.ReSpawnPlayer(model.controls);
        //inputComponent.DestroyComponent();
    }



}
