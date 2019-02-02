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
        
        public Vector3 GetRandomSpawnPoint()
        {
            return new Vector3(Random.Range(-40,41), 5, Random.Range(-40,41));
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