using UnityEngine;
using UnityEditor;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "AchievementObject", menuName = "ScriptableObj/AchievemtObject", order = 1)]
    public class Achievement : ScriptableObject
    {
        public string achievementDisplayName;
        public AchievementsLevel[] achievementLevel;
        public AchievementTypes achievementType;
        public bool sessionBased;


        public void UpdateAchievement(int progress, ControllerPlayer player)
        {
            //Debug.Log("Updating achievement: " + achievementDisplayName);
            int currentLevel = PlayerPrefs.GetInt(achievementDisplayName + player.GetPlayerNumber() + "level", 0);
            
            if (!sessionBased)
            {
                if (currentLevel < achievementLevel.Length)
                {
                    progress = progress + PlayerPrefs.GetInt(achievementDisplayName + player.GetPlayerNumber() + "progress", 0);
                    //Debug.Log(progress);
                    if (achievementLevel[currentLevel].levelMarker <= progress )
                    {

                        PlayerPrefs.SetInt(achievementDisplayName + player.GetPlayerNumber() + "level", ++currentLevel);
                        Debug.Log(achievementDisplayName + " : " + achievementLevel[currentLevel - 1].levelName + " Unlocked by " + player.GetPlayerNumber());
                    }
                }
            }
            else
            {if (currentLevel < achievementLevel.Length)
                {
                    if (achievementLevel[currentLevel].levelMarker <= progress)
                    {

                        PlayerPrefs.SetInt(achievementDisplayName + player.GetPlayerNumber() + "level", ++currentLevel);
                        Debug.Log(achievementDisplayName + " : " + achievementLevel[currentLevel - 1].levelName + " Unlocked by player " + player.GetPlayerNumber());
                    }
                }
            }
            //Debug.Log(currentLevel + " for" + achievementType.ToString() + " " + progress);
            PlayerPrefs.SetInt(achievementDisplayName + player.GetPlayerNumber() + "progress", progress);

        }
    }
}