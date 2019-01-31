using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer:BaseController
{
    
     ViewPlayer view ;
     ModelPlayer model;
     ServiceBullet serviceBullet;
    InputComponent inputComponent;
    public ControllerPlayer(GameObject player,Transform spawnPoint)
    {

        this.view = GameObject.Instantiate(player, spawnPoint.position,Quaternion.identity,null).GetComponent<ViewPlayer>();
        this.model =new ModelPlayer();
        serviceBullet =ServiceBullet.Instance;
        inputComponent = new InputComponent(this);
    }
    public override bool CheckFreez()
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
    public override void Shoot()
    {
        if(model.lastShot+model.fireInterval<Time.timeSinceLevelLoad)
        { 
            model.lastShot = Time.timeSinceLevelLoad;
            ControllerBullet controllerBullet = serviceBullet.MakeBullet(model.bulletType);
            controllerBullet.Shoot(view.muzzle.transform);
        }
    }
    public override void DestroyObject()
    {
        inputComponent.DestroyComponent();
    }


}
