using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerBullet
{
    protected BaseController shooter;
    public abstract void Shoot(Transform muzzle);
    public virtual void Destroy()
    {
        ServiceBullet.Instance.RemoveBullet(this);
    }
    public void SetShooter(BaseController shooter)
    {
        this.shooter = shooter;
    }
    public virtual void HitEnemy(int score)
    {
        Debug.Log("hit enemy");
        shooter.UpdateScore(score);
    }

}
