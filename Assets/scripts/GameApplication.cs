using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApplication : Singleton<GameApplication>
{

    public ScriptableEnemy[] enemy;
    public GameObject spawnPoint,player,spawnPoint2;
    
    public void Awake()
    {
        new ControllerPlayer(player, spawnPoint.transform);
        new ControllerPlayer(player, spawnPoint2.transform);
        
        ServiceEnemy.Instance.SetEnemyList(enemy);
    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
