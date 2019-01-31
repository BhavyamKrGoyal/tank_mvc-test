using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceUI : Singleton<ServiceUI>
{
    //For Changing Between Different UI Screens and any actions to be performed by the UI like Button Press

    ControllerMenuUI menu;
    ControllerStartUI start;
    ControllerPlayer playerController;
    void Start()
    {
        //Set The Menu UI ie: play Button
        start = new ControllerStartUI();
        menu = new ControllerMenuUI();
    }

    public void StartGame()
    {
        menu.DestroyUI();
        start.DisplayUI();
    }
    public void updateUI(int health,int score)
    {
        start.UpdateHealth(health);
        start.UpdateScore(score);
    }
}
