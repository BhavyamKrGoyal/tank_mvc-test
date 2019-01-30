using UnityEngine;
using UnityEditor;
using Enemy.Model;

namespace Enemy.Controller
{
    public class ControllerEnemy
    {
        ModelEnemy model;
        ViewEnemy view;
        public ControllerEnemy(ScriptableEnemy enemyTemp)
        {
            GetModel(enemyTemp);
            GetView();
        }
        public virtual void GetModel(ScriptableEnemy enemyTemp)
        {
            model = new ModelEnemy(enemyTemp);
        }
        public virtual void GetView()
        {
            view = GameObject.Instantiate(model.enemyObject.enemyPrefab, model.enemyObject.spawnPoint, Quaternion.identity, null).GetComponent<ViewEnemy>();
            view.SetColour(model.enemyObject.color);
            view.controller=this;
        }
        public void BulletHit(int damage)
        {
            TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            model.enemyObject.health -= damage;
            if (model.enemyObject.health <= 0)
            {
                model = null;
                view.DestroyEnemy();
                ServiceEnemy.Instance.RemoveEnemy(this);
                
            }

        }
    }
}
