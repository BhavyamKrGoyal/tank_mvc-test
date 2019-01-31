using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelExplossiveBullet : ModelBullet
{


    public ModelExplossiveBullet()
    {
        bodyDamage = 50;
        criticalDamage = 60;
        explosion = true;
    }
}
