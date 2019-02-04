using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBullet
{
    protected ModelBullet model;
    protected ViewBullet view;
    protected BasePlayerController shooter;
    public virtual void Shoot (Transform muzzle){}
    public ControllerBullet()
    {
        getViewAndModel();
        view.controller = this;
        view.time = model.lifeTime;
    }
    public virtual void getViewAndModel()
    {
        model = new ModelBullet();
        view = new ViewBullet();
    }
    public virtual void Destroy()
    {
        ServiceBullet.Instance.RemoveBullet(this);
    }
    public void SetShooter(BasePlayerController shooter)
    {
        this.shooter = shooter;
    }
    public virtual void HitEnemy(int score)
    {
        Debug.Log("hit enemy");
        shooter.UpdateScore(score);
    }

}
