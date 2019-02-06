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
            result.achievementUnlocked=false;
            result.player=player.GetPlayerNumber();
            //Debug.Log("Updating achievement: " + achievementDisplayName);
            int currentLevel = PlayerPrefs.GetInt(achievementDisplayName + player.GetPlayerNumber() + "level", 0);
            
            if (!sessionBased)
            {
                progress = progress + PlayerPrefs.GetInt(achievementDisplayName + player.GetPlayerNumber() + "progress", 0);
            }
                if (IsMaxAchievementLevel(currentLevel))
                {
                    //Debug.Log(progress);
                    if (achievementLevel[currentLevel].levelMarker <= progress )
                    {

                        result.achievementLevel=currentLevel+1;
                        result.achievementLevelName=achievementLevel[currentLevel+1].levelName;
                        result.achievementName=achievementDisplayName;
                        result.achievementProgress=progress;
                    }
                }
            //Debug.Log(currentLevel + " for" + achievementType.ToString() + " " + progress);
            
            return result;

        }
        
    private bool IsMaxAchievementLevel(int currentLevel){
        return currentLevel < achievementLevel.Length;
    }
    }
}