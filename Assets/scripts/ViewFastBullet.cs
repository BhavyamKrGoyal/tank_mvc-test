using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFastBullet : ViewBullet
{
   
    public override void StartShoot(Transform muzzle, float power,float time)
    {
        Destroy(gameObject, time);
        gameObject.transform.position = muzzle.position;
        gameObject.transform.rotation = muzzle.rotation;
        GetComponent<Rigidbody>().velocity = transform.forward * power; ;


    }
}
