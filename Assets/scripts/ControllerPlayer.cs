using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer
{
    
    public ViewPlayer view ;
    public ModelPlayer model;
    public ServiceBullet serviceBullet;
    public ControllerPlayer(GameObject player,Transform spawnPoint,ServiceBullet service)
    {

        this.view = GameObject.Instantiate(player, spawnPoint.position,Quaternion.identity,null).GetComponent<ViewPlayer>();
        this.model =new ModelPlayer();
        this.serviceBullet = service;
    }
    public void moveTank(float h,float v)
    {
        //Debug.Log("controller");
        view.moveTank(h*model.rotationSpeed*Time.deltaTime,v*model.speed*Time.deltaTime*model.boost);

    }

    public void boosting()
    {
        model.boost = 2;
    }
    public void stopboosting()
    {
        model.boost = 1;
    }
    public void shooting()
    {
        if(model.lastShot+model.fireInterval<Time.timeSinceLevelLoad)
        { 
            model.lastShot = Time.timeSinceLevelLoad;
            ControllerBullet controllerBullet = serviceBullet.MakeBullet();
            controllerBullet.Shoot(view.muzzle.transform, model.firePower);
        }
    }
    

}
