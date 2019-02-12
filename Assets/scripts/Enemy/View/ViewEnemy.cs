using Enemy.Controller;
using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnemy : MonoBehaviour, ITakeDamageView
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

    }
    public void TurnTowards(Vector3 position){
        gameObject.transform.LookAt(position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ViewPlayer>() != null)
        {
            controller.SetAlert(other.gameObject.transform.position);
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void TakeDamage(int damage, IBasePlayerController player)
    {
        controller.BulletHit(damage, (ControllerPlayer)player);
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, 12);  
    }
#endif
}
