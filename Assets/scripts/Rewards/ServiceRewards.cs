

using System;
using System.Collections.Generic;
using Achievements;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Rewards
{
    public class ServiceRewards : Singleton<ServiceRewards>
    {
        [SerializeField] List<ScriptableUnlockable> unlockables = new List<ScriptableUnlockable>();
        public RectTransform scrollContent, scrollView;
        public event Action<ControllerReward> OnSelection;
        public RectTransform scrollPlaceHolder;
        public void Start()
        {
            //PlayerPrefs.DeleteAll();
            ServiceAchievements.Instance.OnAchievementUnlocked += UnlockReward;
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
            if (scene.name == "MainMenu")
            {
                scrollPlaceHolder = FindObjectOfType<Canvas>().gameObject.GetComponent<RectTransform>();
                RectTransform obj = Instantiate(scrollView, scrollPlaceHolder);
                scrollContent = obj.GetComponentInChildren<HorizontalLayoutGroup>().gameObject.GetComponent<RectTransform>();
                SetScrollView(unlockables);
            }
        }
        public void UnlockReward(String name, int Id)
        {

            PlayerPrefs.SetInt(Id + "Unlockable", 1);

        }
        public void SetScrollView(List<ScriptableUnlockable> unlockables)
        {
            GameObject obj;
            for (int i = 0; i < unlockables.Count; i++)
            {
                int unlocked = PlayerPrefs.GetInt(unlockables[i].onAchievementIdUnlocked + "Unlockable", 0);

                new ControllerReward(unlockables[i], scrollContent, unlocked == 1);
                //obj.transform.SetParent();
            }
            scrollContent.sizeDelta = new Vector2(scrollContent.sizeDelta.x + ((unlockables.Count - 4) * 111), scrollContent.sizeDelta.y);
        }
        public void Selected(ControllerReward reward)
        {
            OnSelection?.Invoke(reward);
        }
    }
}