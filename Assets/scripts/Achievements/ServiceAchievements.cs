using ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Achievements
{
    public class ServiceAchievements : SingletonScene<ServiceAchievements>
    {

        [SerializeField] private Achievement[] achievements;
        public event Action<string> OnAchievementUnlocked;
        Dictionary<AchievementTypes, Achievement> gameAchievements = new Dictionary<AchievementTypes, Achievement>();
        public override void OnInitialize()
        {
            base.OnInitialize();
            GameApplication.Instance.OnPlayerSpawn += AddListener;

        }


        public void Start()
        {
            ///GameApplication.Instance.OnPlayerSpawn += AddListener;

            foreach (Achievement achievement in achievements)
            {
                gameAchievements.Add(achievement.achievementType, achievement);
            }
           
        }
        public void AddListener(ControllerPlayer player)
        {
            PlayerData playerData = player.playerData;
            player.OnBulletShot += AchievementUpdate;
            player.OnUIUpdate += AchievementUpdate;
            player.OnEnemyKilled += AchievementUpdate;
            //Debug.Log("All listeners added for achievements");
            if (player.GetGameStarted())
            {
                playerData.progress = 1;
                playerData.achievementTypes = AchievementTypes.GamesPlayed;
                AchievementUpdate(playerData);
            }
            else
            {
                playerData.achievementTypes = AchievementTypes.NumberOfRespawns;
                playerData.progress = 1;
                AchievementUpdate(playerData);
            }
        }

        public void AchievementUpdate(PlayerData playerData)
        {
            AchievementData achieved;
            if (gameAchievements.ContainsKey(playerData.achievementTypes))
            {
                achieved=gameAchievements[playerData.achievementTypes].UpdateAchievement(playerData.progress, playerData.player);
                if (achieved.achievementUnlocked)
                {
                    OnAchievementUnlocked.Invoke(achieved.achievementName + " : " + achieved.achievementLevelName + " Unlocked by " + achieved.player);
                     PlayerPrefs.SetInt(achieved.achievementName + achieved.player+ "level", achieved.achievementLevel);
                }
                PlayerPrefs.SetInt(achieved.achievementName + achieved.player + "progress", achieved.achievementProgress);
            }
           
        }
    }
}
