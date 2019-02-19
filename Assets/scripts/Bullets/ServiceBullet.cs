using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces.ServiecesInterface;
using UnityEngine;



public class ServiceBullet : IServiceBullet
{
    public static List<ControllerBullet> bulletList = new List<ControllerBullet>();

    public ControllerBullet MakeBullet(BulletTypes bulletType)
    {
        ControllerBullet temp = null;
        switch (bulletType)
        {
            default:
                temp = new ControllerDefaultBullet();
                bulletList.Add(temp);
                break;

            case BulletTypes.fastBullet:
                temp = new ControllerFastBullet();
                bulletList.Add(temp);
                break;

            case BulletTypes.explossiveBullet:
                temp = new ControllerExplossiveBullet();
                bulletList.Add(temp);
                break;


        }
        temp.OnBulletDestroy += RemoveBullet;
        // Debug.Log(bulletList.Count);
        return temp;
    }


    public void RemoveBullet(ControllerBullet bullet)
    {
        Debug.Log("Destroying bullet");
        // bulletList.Remove(temp);
        bulletList.Remove(bullet);

    }

}
