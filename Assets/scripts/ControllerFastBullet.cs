using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFastBullet : ControllerBullet
{
    ModelFastBullet model;
    ViewFastBullet view;

    public ControllerFastBullet()
    {
        GameObject shell = Resources.Load<GameObject>("FastShell");
        view = GameObject.Instantiate<GameObject>(shell).GetComponent<ViewFastBullet>();
        model = new ModelFastBullet();
        view.controller = this;
        view.time = model.lifeTime;
    }
    public override void Shoot(Transform muzzle)
    {
        view.StartShoot(muzzle, model.power, model.lifeTime);
    }
    public override void Destroy()
    {
        base.Destroy();
        model = null;
        view.DestroyBullet();
    }

}
