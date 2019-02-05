
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer:IBasePlayerController
{
    
     ViewPlayer view ;
     ModelPlayer model;
     public PlayerData playerData;
     InputComponent inputComponent;
    public event Action<PlayerData> OnUIUpdate;
    public event Action<PlayerData> OnBulletShot;
    public event Action<PlayerData> OnEnemyKilled;
    public event Action<ControllerPlayer,InputComponent,Controls> OnPlayerDeath;
    public ControllerPlayer(GameObject player,Vector3 spawnPoint,Controls controls,PlayerNumber playerNumber,bool gameStarted)
    {
       
        this.view = GameObject.Instantiate(player, spawnPoint,Quaternion.identity,null).GetComponent<ViewPlayer>();
        this.model =new ModelPlayer(controls);
        view.SetController(this);
        model.playerNumber = playerNumber;
        model.gameStarted = gameStarted;
        inputComponent =new InputComponent(this);
        playerData.player = this;
        
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
    public void Move(float horizontal,float vertical)
    {
        //Debug.Log("controller");
        view.MovePlayer(horizontal*model.rotationSpeed*Time.deltaTime,vertical*model.speed*Time.deltaTime*model.boost);

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
        playerData.health = model.health;
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
        playerData.health = model.health;
        playerData.progress = model.score;
        playerData.achievementTypes = AchievementTypes.Score;
        OnUIUpdate.Invoke(playerData);

        //ServiceUI.Instance.updateUI(model.health, model.score);
    }
    public void Shoot()
    {
        if(model.lastShot+model.fireInterval<Time.timeSinceLevelLoad)
        {
           
            model.lastShot = Time.timeSinceLevelLoad;
            playerData.achievementTypes = AchievementTypes.BulletsShot;
            playerData.progress = 1;
            ControllerBullet controllerBullet = ServiceBullet.Instance.MakeBullet(model.bulletType);
            OnBulletShot?.Invoke(playerData);
            controllerBullet.SetShooter(this);
            controllerBullet.Shoot(view.muzzle.transform);
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
