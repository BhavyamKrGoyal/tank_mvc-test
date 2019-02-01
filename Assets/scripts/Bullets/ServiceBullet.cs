using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ServiceBullet : SingletonScene<ServiceBullet>
{
    public static List<ControllerBullet> bulletList = new List<ControllerBullet>();
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
       // Debug.Log(bulletList.Count);
        return temp;
    }


    public void RemoveBullet(ControllerBullet temp)
    {
        //Debug.Log(bulletList.Count);
       // bulletList.Remove(temp);
        bulletList.Remove(temp);
        
    }

}
