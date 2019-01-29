using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBullet
{
    ModelBullet model;
    ViewBullet view;

    public ControllerBullet()
    {
        GameObject shell = Resources.Load<GameObject>("Shell");
        view = GameObject.Instantiate<GameObject>(shell).GetComponent<ViewBullet>();
        model = new ModelBullet();
    }
    public void Shoot(Transform muzzle,float power)
    {
        view.StartShoot(muzzle, power);
    }


}
