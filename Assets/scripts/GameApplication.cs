﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElement : MonoBehaviour
{
    public GameApplication app { get { return GameObject.FindObjectOfType<GameApplication>(); } }
}

public class GameApplication : MonoBehaviour
{

    public GameObject spawnPoint,player;
    public ControllerPlayer playerController;
    // Start is called before the first frame update
    void Start()
    {
        ServiceBullet serviceBullet = new ServiceBullet();
        playerController = new ControllerPlayer(player,spawnPoint.transform, serviceBullet);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}