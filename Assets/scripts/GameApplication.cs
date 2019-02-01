using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApplication : MonoBehaviour
{

    public ScriptableEnemy[] enemy;
   
    public GameObject spawnPoint,player,spawnPoint2;
    
    public void Awake()
    {
        Debug.Log("in awake of GameApplication");
        new ControllerPlayer(player, spawnPoint.transform,Controls.WASD);
        new ControllerPlayer(player, spawnPoint2.transform, Controls.IJKL);
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
