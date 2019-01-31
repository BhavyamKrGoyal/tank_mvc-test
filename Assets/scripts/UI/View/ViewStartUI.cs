using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewStartUI {
    Text score;
    Text health;
    public ViewStartUI()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        DestroyUI();
    }

    public void DestroyUI()
    {
        score.gameObject.SetActive(false);
        health.gameObject.SetActive(false);
    }
    public void DisplayUI()
    {
        health.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
    }
    public void UpdateScore(string score)
    {
        this.score.text = score;
    }
    public void UpdateHealth(string health)
    {
        this.health.text = health;
    }
}
