using System;
using System.Collections;
using System.Collections.Generic;
using Achievements;
using Enemy;
using Interfaces;
using Interfaces.ServiecesInterface;
using Rewards;
using Sound;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceLocator : Singleton<ServiceLocator>
{
    // Start is called before the first frame update
    IFrameService frameService;
    IServiceSound soundService;
    List<IServices> services = new List<IServices>();
    InputManager inputManager;
    public override void OnInitialize()
    {
        base.OnInitialize();


    }
    void Start()
    {
        Register<IStateManager>(new StateManager());
        inputManager = new InputManager();
        Register<IInputManager>(inputManager);
        Register<IServiceAchievements>(new ServiceAchievements());
        Register<IServiceRewards>(new ServiceRewards());
        ServiceUI.Instance.SetListeners();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            if (soundService == null)
            {
                soundService = new ServiceSound();
                Register<IServiceSound>(soundService);
            }
            frameService = new FrameService();
            Register<IFrameService>(frameService);
            ServiceEnemy enemyservice = new ServiceEnemy();
            Register<IServiceEnemy>(enemyservice);
            enemyservice.StartSpawning();
            Register<IServiceBullet>(new ServiceBullet());
        }
        else
        {
            frameService = null;
            for (int i = 0; i < services.Count; i++)
            {
                //Debug.Log(services[i]);
                if (services[i] is IServiceEnemy || services[i] is IServiceBullet || services[i] is IFrameService)
                {
                    Debug.Log(services[i]);
                    services.RemoveAt(i);
                }
            }
        }
    }
    private void Register<T>(T service) where T : IServices
    {
        services.Add(service);
    }
    public T get<T>() where T : IServices
    {
        T serve = default(T);
        foreach (IServices service in services)
        {
            if (service is T)
            {
                serve = (T)service;
                break;
            }
        }
        return serve;
    }


    // Update is called once per frame
    void Update()
    {
        if (frameService != null)
        {
            frameService.Update();
        }
        inputManager.Update();
    }
}
