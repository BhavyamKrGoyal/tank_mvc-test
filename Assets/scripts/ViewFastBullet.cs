using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFastBullet : MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, 3);
    }
    public void StartShoot(Transform muzzle, float power)
    {
        gameObject.transform.position = muzzle.position;
        gameObject.transform.rotation = muzzle.rotation;
        GetComponent<Rigidbody>().velocity = transform.forward * power; ;

    }
}
