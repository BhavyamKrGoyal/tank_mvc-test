using System;
using System.Collections;
using System.Collections.Generic;
using Achievements;
using Interfaces;
using Interfaces.ServiecesInterface;
using Rewards;
using StateMachines;
using UnityEngine;

public class ServiceLocator : Singleton<ServiceLocator>
{
    // Start is called before the first frame update
    List<IServices> services = new List<IServices>();
    InputManager inputManager;
    void Start()
    {
        Register<IStateManager>(new StateManager());
        inputManager = new InputManager();
        Register<IInputManager>(inputManager);
        Register<IServiceAchievements>(new ServiceAchievements());
        Register<IServiceRewards>(new ServiceRewards());
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
        inputManager.Update();
    }
}
