using Enemy.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnemy : MonoBehaviour
{
    public ControllerEnemy controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetColour(Color color)
    {
        gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", color);
    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            controller.BulletHit(100);
        }
    }
}
