using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "AchievementObject", menuName = "ScriptableObj/AchievemtObject", order = 1)]
public class Achievement : ScriptableObject
{
    public string achievementName;
    public int[] achievementMarkers;
    public AchievemtTypes AchievementOn; 
}