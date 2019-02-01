using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer:BasePlayerController
{
    
     ViewPlayer view ;
     ModelPlayer model;
     InputComponent inputComponent;

    public ControllerPlayer(GameObject player,Transform spawnPoint,Controls controls)
    {
      
        this.view = GameObject.Instantiate(player, spawnPoint.position,Quaternion.identity,null).GetComponent<ViewPlayer>();
        this.model =new ModelPlayer(controls);
        view.SetController(this);
        inputComponent=new InputComponent(this);
        
    }
    public override Controls GetControls()
    {
        return model.controls;
    }
    public override bool IsFreez()
    {
        return model.freez;
    }
    public override void Move(float horizontal,float vertical)
    {
        //Debug.Log("controller");
        view.MovePlayer(horizontal*model.rotationSpeed*Time.deltaTime,vertical*model.speed*Time.deltaTime*model.boost);

    }

    public override void StartBoost()
    {
        model.boost = 2;
    }
    public override void StopBoost()
    {
        model.boost = 1;
    }
    
    public void TankHit(int damage)
    {
        model.TakeDamage(damage);
        if (!model.IsAlive())
        {
            DestroyObject();
        }
        ServiceUI.Instance.updateUI(model.health, model.score);
    }
    public override void UpdateScore(int score)
    {
        model.score = model.score + score;
        ServiceUI.Instance.updateUI(model.health, model.score);
    }
    public override void Shoot()
    {
        if(model.lastShot+model.fireInterval<Time.timeSinceLevelLoad)
        {
           
            model.lastShot = Time.timeSinceLevelLoad;
            ControllerBullet controllerBullet = ServiceBullet.Instance.MakeBullet(model.bulletType);
            controllerBullet.SetShooter(this);
            controllerBullet.Shoot(view.muzzle.transform);
        }
    }
    public override void DestroyObject()
    {
        view.DestroyPlayer();
        inputComponent.DestroyComponent();
    }


}
