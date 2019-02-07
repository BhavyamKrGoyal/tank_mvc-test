using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerStartUI
{
    // For Controlling the UI in the Start screen
    ViewStartUI view;
    public ControllerStartUI()
    {
        view = GameObject.FindObjectOfType<ViewStartUI>().GetComponent<ViewStartUI>();
        DisplayUI();
    }
    public void DestroyUI()
    {
        view.DestroyUI();
    }
    public void DisplayUI()
    {
        view.DisplayUI();
    }
    public void UpdateScore(int score)
    {
        string scoreView = "Score : " + score;
        view.UpdateScore(scoreView);
    }
    public void UpdateHealth(int health)
    {
        string healthView = "Health : " + health;
        view.UpdateHealth(healthView);
    }
}
