using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElement : MonoBehaviour
{
    public GameApplication app { get { return GameObject.FindObjectOfType<GameApplication>(); } }
}

public class GameApplication : MonoBehaviour
{

    public ScriptableEnemy[] enemy;
    public GameObject spawnPoint,player;
    public ControllerPlayer playerController;
    public void Awake()
    {
        playerController = new ControllerPlayer(player, spawnPoint.transform);
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
