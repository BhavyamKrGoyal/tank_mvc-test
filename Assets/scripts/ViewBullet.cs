using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewBullet : MonoBehaviour
{
    public abstract void StartShoot(Transform muzzle, float power);
}
