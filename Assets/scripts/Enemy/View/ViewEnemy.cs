using Enemy.Controller;
using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{


    public class ViewEnemy : MonoBehaviour, ITakeDamageView
    {
        public ControllerEnemy controller;
        Rigidbody rb;
        public ViewEnemyComponentChasing chasing;
        public ViewEnemyComponentPetrolling petrolling;

        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();

        }
        public void StateChange(EnemyState state){
            controller.StateChangeNotify(state);
        }
        private void Update()
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
        public void TurnTowards(Vector3 position)
        {
            gameObject.transform.LookAt(position);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<ViewPlayer>() != null)
            {
                controller.SetAlert(other.gameObject.transform.position);
            }
        }
        public void ActivateState(EnemyState state,Vector3 position)
        {
            switch (state)
            {
                case EnemyState.Chansing:chasing.enabled=true; chasing.SetFollowPosition(position); break;
                case EnemyState.Petrolling:petrolling.enabled=true; break;
            }
        }
        public void DeactivateState(EnemyState state)
        {  
            switch (state)
            {
                case EnemyState.Chansing:chasing.enabled=false; break;
                case EnemyState.Petrolling:petrolling.enabled=false; break;
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
}