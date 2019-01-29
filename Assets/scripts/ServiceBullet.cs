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
public class ServiceBullet
{ 
    public ControllerBullet MakeBullet(BulletTypes bulletType)
    {

            switch (bulletType)
            {
                case BulletTypes.defaultBullet: return new ControllerDefaultBullet();
                                                break;
                case BulletTypes.fastBullet: return new ControllerFastBullet();
                                                break;
                case BulletTypes.explossiveBullet: return new ControllerExplossiveBullet();
                                                break;
        }
        return new ControllerDefaultBullet();
    }
}
