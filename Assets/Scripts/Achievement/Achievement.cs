using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievements/Achievement")]
public class Achievement : ScriptableObject
{
    public string title;
    public string description;
    public AchievementType achievementType;

    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    public float requiredProgress;
    public float currentProgress;

    public bool isUnlocked;

    public void IncrementProgress(float amount)
    {
        if (!isUnlocked)
        {
            currentProgress += amount;

            if (currentProgress >= requiredProgress)
            {
                Unlock();
            }
        }
    }

    public void SetProgress(float amount)
    {
        if (!isUnlocked)
        {
            currentProgress = amount;

            if (currentProgress >= requiredProgress)
            {
                Unlock();
            }
        }
    }

    private void Unlock()
    {
        isUnlocked = true;
    }
}

public enum AchievementType
{
    Forge,
    Crafting,
    Misc
}
