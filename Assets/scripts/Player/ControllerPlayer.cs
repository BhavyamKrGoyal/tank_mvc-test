
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer:IBasePlayerController
{
    
     ViewPlayer view ;
     ModelPlayer model;
     InputComponent inputComponent;
    public event Action<int,int> OnUIUpdate;
    public event Action<ControllerPlayer,InputComponent,Controls> OnPlayerDeath;
    public event Action<BulletTypes> OnBulletNeeded;
    public ControllerPlayer(GameObject player,Vector3 spawnPoint,Controls controls,PlayerNumber playerNumber)
    {
       
        this.view = GameObject.Instantiate(player, spawnPoint,Quaternion.identity,null).GetComponent<ViewPlayer>();
        this.model =new ModelPlayer(controls);
        view.SetController(this);
        model.playerNumber = playerNumber;
        inputComponent=new InputComponent(this);
        
        
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
        OnUIUpdate.Invoke(model.health, model.score);
        if (!model.IsAlive())
        {
            DestroyObject();
        }
        
        //ServiceUI.Instance.updateUI(model.health, model.score);
    }
    public void UpdateScore(int score)
    {
        model.score = model.score + score;
        OnUIUpdate.Invoke(model.health, model.score);

        //ServiceUI.Instance.updateUI(model.health, model.score);
    }
    public void Shoot()
    {
        if(model.lastShot+model.fireInterval<Time.timeSinceLevelLoad)
        {
           
            model.lastShot = Time.timeSinceLevelLoad;
            ControllerBullet controllerBullet = ServiceBullet.Instance.MakeBullet(model.bulletType);
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
