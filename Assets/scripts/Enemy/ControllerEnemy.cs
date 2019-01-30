using UnityEngine;
using UnityEditor;

public class ControllerEnemy
{
    ModelEnemy model;
    ViewBullet view;
    public ControllerEnemy(ScriptableObject enemyTemp)
    {
        GetModelAndView(enemyTemp);
        
    }

    public virtual void GetModelAndView(ScriptableObject enemyTemp) {
        model = new ModelEnemy(enemyTemp);
    }
}