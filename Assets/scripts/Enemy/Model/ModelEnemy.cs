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

    }
}