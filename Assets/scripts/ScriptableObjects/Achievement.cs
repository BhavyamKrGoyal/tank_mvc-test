using UnityEngine;
using UnityEditor;
using Achievements;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "AchievementObject", menuName = "ScriptableObj/AchievemtObject", order = 1)]
    public class Achievement : ScriptableObject
    {
        public string achievementDisplayName;
        public AchievementsLevel[] achievementLevel;
        public AchievementTypes achievementType;
        public bool sessionBased;


        public AchievementData UpdateAchievement(int progress, ControllerPlayer player)
        {
            AchievementData result = new AchievementData();
            result.achievementUnlocked = false;
            //Debug.Log(achievementType);
            result.achievementName = achievementDisplayName;
            result.player = player.GetPlayerNumber();
            int currentLevel = PlayerPrefs.GetInt(achievementDisplayName + player.GetPlayerNumber() + "level", 0);
            result.achievementLevel = currentLevel;
            result.achievementId = achievementLevel[currentLevel].UniqueId;
            result.achievementLevelName = achievementLevel[currentLevel].levelName;
            progress = progress + PlayerPrefs.GetInt(achievementDisplayName + player.GetPlayerNumber() + "progress", 0);
            //Debug.Log("Updating achievement: " + achievementDisplayName + " " + progress);
            if (IsMaxAchievementLevel(currentLevel))
            {
                //Debug.Log(progress + " " + achievementDisplayName);
                if (achievementLevel[currentLevel].levelMarker <= progress)
                {

                    result.achievementUnlocked = true;
                    result.achievementLevel = ++currentLevel;
                    result.achievementId = achievementLevel[currentLevel-1].UniqueId;
                    result.achievementLevelName = achievementLevel[currentLevel-1].levelName;

                }
            }
            result.achievementProgress = progress;

            //Debug.Log(currentLevel + " for" + achievementType.ToString() + " " + progress);

            return result;

        }

        private bool IsMaxAchievementLevel(int currentLevel)
        {
            return currentLevel < achievementLevel.Length;
        }
    }
}