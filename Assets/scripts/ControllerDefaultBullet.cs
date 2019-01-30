using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDefaultBullet : ControllerBullet
{
    ModelDefaultBullet model;
    ViewDefaultBullet view;

    public ControllerDefaultBullet()
    {
        GameObject shell = Resources.Load<GameObject>("DefaultShell");
        view = GameObject.Instantiate<GameObject>(shell).GetComponent<ViewDefaultBullet>();
        model = new ModelDefaultBullet();
        view.controller = this;
        view.time = model.lifeTime;
    }
    public override void Shoot(Transform muzzle)
    {
        view.StartShoot(muzzle, model.power,model.lifeTime);
    }
    public override void Destroy()
    {
        base.Destroy();
        model = null;
        view.DestroyBullet();
    }


}
