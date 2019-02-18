using Interfaces;
using Interfaces.ServiecesInterface;
using StateMachines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBullet
{
    protected ModelBullet model;
    protected ViewBullet view;
    protected IBasePlayerController shooter;
    public event Action<ControllerBullet> OnBulletDestroy;
    public virtual void Shoot(Transform muzzle) { }
    public ControllerBullet()
    {
        getViewAndModel();
        view.controller = this;
        //view.time = model.lifeTime;
        ServiceLocator.Instance.get<IStateManager>().OnStateChanged += GameStateChanged;
    }
    public void GameStateChanged(GameState currentState)
    {
        if (currentState is GamePauseState)
        {
            view.BulletPaused();
        }
        else
        {
            view.BulletResume();
        }
    }
    public int GetDamage()
    {
        return model.bodyDamage;
    }
    public virtual void getViewAndModel()
    {
        model = new ModelBullet();
        view = new ViewBullet();
    }
    public virtual void Destroy()
    {
        OnBulletDestroy(this);
    }
    public void SetShooter(IBasePlayerController shooter)
    {
        this.shooter = shooter;
    }
    public virtual IBasePlayerController GetShooter()
    {
        return shooter;
    }

}
