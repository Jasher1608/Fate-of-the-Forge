using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementManager", menuName = "Achievements/AchievementManager")]
public class AchievementManager : ScriptableObject
{
    public List<Achievement> achievements;

    public void Initialize()
    {
        foreach(Achievement achievement in achievements)
        {
            achievement.currentProgress = 0;
            achievement.isUnlocked = false;
        }
    }
}
