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
    }
}