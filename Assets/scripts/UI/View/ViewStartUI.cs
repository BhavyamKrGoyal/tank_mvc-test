using Achievements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewStartUI : MonoBehaviour
{
    Text score;
    Text health;
    Text achievement;
    public void Start()
    {
        if (ServiceAchievements.Instance != null)
        {
            ServiceAchievements.Instance.OnAchievementUnlocked += AchievementUnlocked;
        }
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        achievement= GameObject.FindGameObjectWithTag("AchievementUI").GetComponent<Text>();
        DestroyUI();
    }

    public void DestroyUI()
    {
        achievement.gameObject.SetActive(false);
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
    public void AchievementUnlocked(string display)
    {
        StartCoroutine(DisplayAchievement(display));
    }
    IEnumerator DisplayAchievement(string display)
    {
        achievement.gameObject.SetActive(true);
        achievement.text = display;
        yield return new WaitForSeconds(3f);
        achievement.gameObject.SetActive(false);
    }
}
