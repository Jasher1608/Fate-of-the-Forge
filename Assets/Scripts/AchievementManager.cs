using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private GeneratorMono ironBarMono;
    [SerializeField] private GeneratorMono copperBarMono;
    [SerializeField] private GeneratorMono silverBarMono;
    [SerializeField] private GeneratorMono goldBarMono;
    
    public List<Achievement> achievements;

    public bool AchievementUnlocked(string achievementName)
    {
        bool result = false;

        if (achievements == null)
        {
            return false;
        }

        Achievement[] achievementArray = achievements.ToArray();
        Achievement a = Array.Find(achievementArray, ach => achievementName == ach.title);

        if (a == null)
        {
            return false;
        }

        result = a.achieved;

        return result;
    }

    private void Start()
    {
        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        if (achievements != null)
        {
            return;
        }

        achievements = new List<Achievement>();
        AddAchievements();
    }

    private void Update()
    {
        CheckAchievementCompletion(); // Optimise later
    }

    private void CheckAchievementCompletion()
    {
        if (achievements == null)
        {
            return;
        }

        foreach (var achievement in achievements)
        {
            achievement.UpdateCompletion();
        }
    }

    public void AddAchievements()
    {
        achievements.Add(new Achievement("Forging a new beginning", "Acquired 25 Iron Bar generators", (object o) => ironBarMono._quantity >= 25));
    }
}

public class Achievement
{
    public Achievement(string title, string description, Predicate<object> requirement)
    {
        this.title = title;
        this.description = description;
        this.requirement = requirement;
    }

    public string title;
    public string description;
    public Predicate<object> requirement;

    public bool achieved;

    public void UpdateCompletion()
    {
        if (achieved)
        {
            return;
        }

        if (RequirementsMet())
        {
            // Add achievement bonuses/ui here
            Debug.Log($"{title}: {description}");
            achieved = true;
        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}