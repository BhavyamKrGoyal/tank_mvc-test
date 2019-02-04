using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Enemy.Controller;

namespace Enemy
{
    public class ServiceEnemy : SingletonScene<ServiceEnemy>
    {
        ScriptableEnemy[] enemyList;
        List<ControllerEnemy> enemyController = new List<ControllerEnemy>();
        void Start()
        {
            for (int j = 0; j < 20; j++)
            {
                SpawnEnemy();
            }
        }

        public void Update()
        {

        }
        public List<Vector3> GetEnemyPositions()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach(ControllerEnemy controller in enemyController)
            {
                positions.Add(controller.GetEnemyPosition());
            }
            return positions;
        }
        public void SetEnemyList(ScriptableEnemy[] enemyList)
        {
            this.enemyList = enemyList;
        }
        public void SpawnEnemy()
        {
            int enemyType = Random.Range(0, 3);
            enemyController.Add(new ControllerEnemy(enemyList[enemyType]));

        }
        public void RemoveEnemy(ControllerEnemy enemy)
        {
            enemyController.Remove(enemy);
        }
    }
}