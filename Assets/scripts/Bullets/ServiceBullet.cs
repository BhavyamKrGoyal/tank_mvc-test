using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces.ServiecesInterface;
using ObjectPooling;
using UnityEngine;



public class ServiceBullet : IServiceBullet
{
    ObjectPool<ControllerBullet> bulletPool;
    //public static List<ControllerBullet> bulletList = new List<ControllerBullet>();
    public ServiceBullet(){
         bulletPool=new ObjectPool<ControllerBullet>();
    }
    public ControllerBullet MakeBullet(BulletTypes bulletType)
    {
        ControllerBullet bullet = null;
        switch (bulletType)
        {
            default:
                bullet = bulletPool.GetFromPool<ControllerDefaultBullet>();
                break;

            case BulletTypes.fastBullet:
                bullet = bulletPool.GetFromPool<ControllerFastBullet>();
                break;

            case BulletTypes.explossiveBullet:
                bullet = bulletPool.GetFromPool<ControllerExplossiveBullet>();
                break;
        }
        bullet.OnBulletDestroy += RemoveBullet;
        return bullet;
    }


    public void RemoveBullet(ControllerBullet bullet)
    {
         bullet.OnBulletDestroy -= RemoveBullet;
        //Debug.Log("Destroying bullet");
        // bulletList.Remove(temp);
        //bulletList.Remove(bullet);
        bulletPool.ReturnToPool(bullet);

    }

}
