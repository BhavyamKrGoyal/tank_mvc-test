using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Enemy.Controller;
using ScriptableObjects;
using Replay_Service;

namespace Enemy
{
    public class ServiceEnemy : SingletonScene<ServiceEnemy>
    {
        ScriptableEnemy[] enemyList;
        public event System.Action<Vector3> OnAlert;
        List<ControllerEnemy> enemyController = new List<ControllerEnemy>();
        void Start()
        {
            for (int j = 0; j < 10; j++)
            {
                SpawnEnemy();
            }
            ServiceReplay.Instance.OnEnemySpawn();

        }

        public void Update()
        {
        }
        public void SetAlert(Vector3 playerPos)
        {
            OnAlert.Invoke(playerPos);
        }
        public List<EnemyData> GetEnemyData()
        {
            List<EnemyData> enemyData = new List<EnemyData>();
            foreach (ControllerEnemy enemy in enemyController)
            {
                EnemyData data = new EnemyData();
                data.type = enemy.GetEnemyType();
                data.position = enemy.GetEnemyPosition();
                enemyData.Add(data);
            }
            return enemyData;
        }
        public List<Vector3> GetEnemyPositions()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (ControllerEnemy controller in enemyController)
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
            enemyController.Add(new ControllerEnemy(enemyList[enemyType], enemyType));

        }
        public void SpawnEnemy(EnemyData enemy)
        {
            enemyController.Add(new ControllerEnemy(enemyList[enemy.type], enemy.position, enemy.type));
        }
        public void RemoveEnemy(ControllerEnemy enemy)
        {
            enemyController.Remove(enemy);
        }
        public void RemoveAllEnemy()
        {

            for (int i = enemyController.Count - 1; i >= 0; i--)
            {
                enemyController[i].DestroyObject();
                //RemoveEnemy(enemyController[i]);
            }
        }
    }
}