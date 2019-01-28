using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller
{
    public PlayerView view ;
    public TankModel model;
    public controller() { }
    public controller(PlayerView view, TankModel model)
    {
        this.view = view;
        this.model = model;
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
       
            view.Startshoot(model.firePower,model.fireInterval);
            
       
    }
    

}
