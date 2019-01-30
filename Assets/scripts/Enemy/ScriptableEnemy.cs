using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ScriptableEnemy", menuName = "ScriptableObj/EnemyObject", order = 0)]
public class SriptableEnemy : ScriptableObject
{
    public float health;
    public GameObject EnemeyPrefab;
    public float Speed;
    public Color color;
   
}