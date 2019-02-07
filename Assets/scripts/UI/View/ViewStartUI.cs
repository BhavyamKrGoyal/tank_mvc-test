using Achievements;
using StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewStartUI : MonoBehaviour
{   
    [SerializeField]public Text score;
    [SerializeField]public Button pause;
    [SerializeField]public Text health;
    [SerializeField]public Text achievement;
    public void Start()
    {
        if (ServiceAchievements.Instance != null)
        {
            ServiceAchievements.Instance.OnAchievementUnlocked += AchievementUnlocked;
        }
       
        
      //
      
    }
    public void GamePaused(){
        StateManager.Instance.ChangeState(new GamePauseState(),false);
    }
    public void DestroyUI()
    {
        pause.gameObject.SetActive(false);
        achievement.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
        health.gameObject.SetActive(false);
         pause.onClick.RemoveListener(GamePaused);
    }
    public void DisplayUI()
    {
        pause.gameObject.SetActive(true);
        health.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
        pause.onClick.AddListener(GamePaused);
    }
    public void UpdateScore(string scor)
    {
        score.text = scor;
    }
    public void UpdateHealth(string healt)
    {
        health.text = healt;
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
