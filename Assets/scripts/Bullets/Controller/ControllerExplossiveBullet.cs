using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerExplossiveBullet : ControllerBullet
{
    ModelExplossiveBullet model;
    ViewExplossiveBullet view;
   

    public ControllerExplossiveBullet()
    {
        GameObject shell = Resources.Load<GameObject>("ExplossiveShell");
        view = GameObject.Instantiate<GameObject>(shell).GetComponent<ViewExplossiveBullet>();
        model = new ModelExplossiveBullet();
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
