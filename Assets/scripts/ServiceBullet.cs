using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletTypes
{
    defaultBullet = 1,
    fastBullet = 2,
    explossiveBullet = 3
}
public class ServiceBullet : Singleton<ServiceBullet>
{
    List<ControllerBullet> bulletList = new List<ControllerBullet>();
    public ControllerBullet MakeBullet(BulletTypes bulletType)
    {
        ControllerBullet temp=null;
            switch (bulletType)
            {
                case BulletTypes.defaultBullet: temp=new ControllerDefaultBullet();
                bulletList.Add(temp);
                break;
                                               
                case BulletTypes.fastBullet: temp=new ControllerFastBullet();
                bulletList.Add(temp);
                break;

                case BulletTypes.explossiveBullet: temp= new ControllerExplossiveBullet();
                bulletList.Add(temp);
                break;

            }
        return temp;
    }


    public void RemoveBullet(ControllerBullet temp)
    {
        bulletList.Remove(temp);

    }

}
