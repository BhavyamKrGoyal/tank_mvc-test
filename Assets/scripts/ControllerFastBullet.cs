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
    }
    public override void Shoot(Transform muzzle)
    {
        view.StartShoot(muzzle, model.power, model.lifeTime);
    }


}
