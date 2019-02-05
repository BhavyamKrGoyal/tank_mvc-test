using UnityEngine;
using UnityEditor;
using Enemy.Model;
using Interfaces;
using ScriptableObjects;

namespace Enemy.Controller
{
    public class ControllerEnemy: IBasePlayerController
    {
        ModelEnemy model;
        ViewEnemy view;
        public ControllerEnemy(ScriptableEnemy enemyTemp)
        {
            GetModel(enemyTemp);
            GetView();
        }
        public Vector3 GetEnemyPosition()
        {
            return view.GetPosition();
        }
        public virtual void GetModel(ScriptableEnemy enemyTemp)
        {
            model = new ModelEnemy(enemyTemp);
        }
        public virtual void GetView()
        {
            view = GameObject.Instantiate(model.enemyObject.enemyPrefab, model.GetRandomSpawnPoint(), Quaternion.identity, null).GetComponent<ViewEnemy>();
            view.SetColour(model.enemyObject.color);
            view.controller=this;
        }
        public void BulletHit(int damage,ControllerPlayer player)
        {
            model.TakeDamage(damage);
            
           // Debug.Log(model.IsAlive());
            if (!model.IsAlive())
            {
                player.EnemyKilled(model.GetScore());
                DestroyObject();    
            }
        }
        public int GetScore()
        {
            return model.GetScore();
        }
        
       
        public void DestroyObject()
        {
            model = null;
            view.DestroyEnemy();
            ServiceEnemy.Instance.RemoveEnemy(this);
        }
        public void Move(float horizontal, float vertical)
        {
           
        }
        public bool IsFreez()
        {
            return model.freez; ;
        }
        public void Shoot()
        {

        }

    
        public Controls GetControls()
        {
            throw new System.NotImplementedException();
        }

        public void StartBoost()
        {
            throw new System.NotImplementedException();
        }

        public void StopBoost()
        {
            throw new System.NotImplementedException();
        }
    }
}
