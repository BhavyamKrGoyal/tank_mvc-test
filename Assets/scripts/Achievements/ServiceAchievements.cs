using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Achievements
{
    public class ServiceAchievements : SingletonScene<ServiceAchievements>
    {

        [SerializeField] private Achievement[] achievements;

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
            if (gameAchievements.ContainsKey(playerData.achievementTypes))
            {
                gameAchievements[playerData.achievementTypes].UpdateAchievement(playerData.progress, playerData.player);
            }
            else
            {
                //Debug.Log("not set"+playerData.achievementTypes.ToString());
            }
        }
    }
}
