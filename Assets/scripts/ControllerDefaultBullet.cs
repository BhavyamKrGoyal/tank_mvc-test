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
    }
    public override void Shoot(Transform muzzle)
    {
        view.StartShoot(muzzle, model.power,model.lifeTime);
    }


}
