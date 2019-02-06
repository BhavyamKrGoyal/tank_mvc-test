using UnityEngine;
using UnityEditor;

public struct PlayerData
{
    public ControllerPlayer player;
    public int progress;
    public int score;
    public int health;
    public AchievementTypes achievementTypes;
}
public struct AchievementData{
    public string achievementName;
    public int achievementLevel;
    public string achievementLevelName;
    public int achievementProgress;
    public bool achievementUnlocked;
    public PlayerNumber player;
}