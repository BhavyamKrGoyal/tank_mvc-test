using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewExplossiveBullet : ViewBullet
{
    public GameObject explossion;
    

    public override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);
       
        Instantiate(explossion,transform.position,Quaternion.identity, null);
    }
}
