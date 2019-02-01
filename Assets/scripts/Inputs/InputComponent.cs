using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent 
{
    BasePlayerController controller;

    public InputComponent(BasePlayerController controller) {
        this.controller = controller;
        InputManager.Instance.RegisterInputComponent(this);
    }
    public void InputUpdate(float forward,float direction,bool shoot,bool boost)
    {
        controller.Move(forward,direction);
        if (shoot)
        {
            controller.Shoot();
        }
        if (boost)
        {
            controller.StartBoost();
        }
        else
        {
            controller.StopBoost();
        }
       //Debug.Log("Updating InputComponent");
    }

    public void Move(float horizontal,float vertical)
    {
        if (!controller.IsFreez())
        {
            controller.Move(horizontal, vertical);
        }
    }
    public void DestroyComponent()
    {
        InputManager.Instance.RemoveInputComponent(this);
            
    }
}
