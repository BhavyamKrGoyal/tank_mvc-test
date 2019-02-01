using UnityEngine;
using UnityEditor;
using Enemy.Model;
using Player;

namespace Enemy.Controller
{
    public class ControllerEnemy: BasePlayerController
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
            view = GameObject.Instantiate(model.enemyObject.enemyPrefab, model.GetRandomSpawnPoint(), Quaternion.identity, null).GetComponent<ViewEnemy>();
            view.SetColour(model.enemyObject.color);
            view.controller=this;
        }
        public void BulletHit(int damage)
        {
            model.TakeDamage(damage);
            if (!model.IsAlive())
            {
                DestroyObject();    
            }
        }

        
       
        public override void DestroyObject()
        {
            model = null;
            view.DestroyEnemy();
            ServiceEnemy.Instance.RemoveEnemy(this);
        }
        public override void Move(float horizontal, float vertical)
        {
           
        }
        public override bool IsFreez()
        {
            return model.freez; ;
        }
        public override void Shoot()
        {

        }
    }
}
