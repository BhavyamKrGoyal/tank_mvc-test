using System.Collections;
using System.Collections.Generic;
using Achievements;
using StateMachines;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{


    public class ViewGamePlayUI : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public Text achievement;
        [SerializeField] public GameObject MainPanal;
        [SerializeField] public Button pause;
        void Start()
        {
            if (ServiceAchievements.Instance != null)
            {
                ServiceAchievements.Instance.OnAchievementUnlocked += AchievementUnlocked;
            }

        }
        public void AchievementUnlocked(string display, int achievementId)
        {
            StartCoroutine(DisplayAchievement(display));
        }
        public void GamePaused()
        {
            StateManager.Instance.ChangeState(new GamePauseState(), false);
        }
        public void DestroyUI()
        {
            pause.gameObject.SetActive(false);
            MainPanal.gameObject.SetActive(false);
            achievement.gameObject.SetActive(false);
            pause.onClick.RemoveListener(GamePaused);
        }
        public void DisplayUI()
        {
            pause.gameObject.SetActive(true);
            MainPanal.gameObject.SetActive(true);
            pause.onClick.AddListener(GamePaused);
        }
        IEnumerator DisplayAchievement(string display)
        {
            achievement.gameObject.SetActive(true);
            achievement.text = display;
            yield return new WaitForSeconds(3f);
            achievement.gameObject.SetActive(false);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
