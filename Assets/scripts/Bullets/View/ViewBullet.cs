using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBullet : MonoBehaviour
{
    public ControllerBullet controller;
    public float time;
    public virtual void StartShoot(Transform muzzle, float power, float time)
    {
        StartCoroutine(DeathTimer());
        gameObject.transform.position = muzzle.position;
        gameObject.transform.rotation = muzzle.rotation;
        GetComponent<Rigidbody>().velocity = transform.forward * power; ;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(time);
        controller.Destroy();
        DestroyBullet();
    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        ITakeDamageView damageView = collision.gameObject.GetComponent<ITakeDamageView>();
        if (damageView!=null)
        {
            
            
            damageView.TakeDamage(controller.GetDamage(),controller.GetShooter());  
            Destroy(gameObject);
        }
    }


}
