using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Enemy.Controller;

namespace Enemy
{
    public class ServiceEnemy : Singleton<ServiceEnemy>
    {
        ScriptableEnemy[] enemyList;
        List<ControllerEnemy> enemyController = new List<ControllerEnemy>();
        void Start()
        {
            SpawnEnemy();
        }

        public void Update()
        {

        }
        public void SetEnemyList(ScriptableEnemy[] enemyList)
        {
            this.enemyList = enemyList;
        }
        public void SpawnEnemy()
        {
            int enemyType = Random.Range(0,3);
            new ControllerEnemy(enemyList[enemyType]);

        }
        public void RemoveEnemy(ControllerEnemy enemy)
        {
            enemyController.Remove(enemy);
        }
    }
}