using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewExplossiveBullet : ViewBullet
{
    public GameObject explossion;
    public void Start()
    {
        Destroy(gameObject, 3);
    }
    public override void StartShoot(Transform muzzle, float power)
    {
        gameObject.transform.position = muzzle.position;
        gameObject.transform.rotation = muzzle.rotation;
        GetComponent<Rigidbody>().velocity = transform.forward * power; ;
    }
    public void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
        Instantiate(explossion,col.transform.position,Quaternion.identity, null);
    }
}
