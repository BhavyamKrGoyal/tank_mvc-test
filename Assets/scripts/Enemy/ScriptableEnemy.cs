using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ScriptableEnemy", menuName = "ScriptableObj/EnemyObject", order = 0)]
public class ScriptableEnemy : ScriptableObject
{
    public float health;
    public ViewEnemy enemyPrefab;
    public float Speed;
    public Color color;
    
   
}