using UnityEngine;
using UnityEditor;
namespace Enemy.Model
{
    public class ModelEnemy
    {
        public ScriptableEnemy enemyObject;
        public ModelEnemy(ScriptableEnemy enemyTemp)
        {
            enemyObject = enemyTemp;
        }
        public bool freez = false;
        public Vector3[] spawnPoint = new Vector3[] { new Vector3(-10, 2, 22), new Vector3(-4, 2, 30), new Vector3(23, 2, -30) };
        public Vector3 GetRandomSpawnPoint()
        {
            return spawnPoint[Random.Range(0, 3)];
        }
        public void TakeDamage(int damage)
        {
            enemyObject.health -= damage;
            
        }
        public bool IsAlive()
        {
            return enemyObject.health >= 0;
            
            
        }
    }
}