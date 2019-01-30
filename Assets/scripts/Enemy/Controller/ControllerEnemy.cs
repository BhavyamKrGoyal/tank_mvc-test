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
        }
    }
}
