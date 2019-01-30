using UnityEngine;
using UnityEditor;

public class ServiceEnemy : Singleton<ServiceEnemy>
{
    ScriptableObject[] enemyList;

    public void Update()
    {
        
    }
    public void SetEnemyList(ScriptableObject[] enemyList)
    {
        this.enemyList = enemyList;
    }
}