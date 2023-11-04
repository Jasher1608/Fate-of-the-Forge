using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour
{
    public AchievementManager achievementManager;

    public GameObject tooltipPrefab;

    public List<Achievement> unlocked = new List<Achievement>();

    [SerializeField] private GameObject achievementUnlockedPrefabParent;
    [SerializeField] private GameObject achievementUnlockedPrefab;
    private AchievementUnlocked achievementUnlocked;

    [SerializeField] private GameObject forgeTrophies;
    [SerializeField] private GameObject craftingTrophies;
    [SerializeField] private GameObject miscTrophies;

    [SerializeField] private GameObject forgeTrophyPrefab;
    [SerializeField] private GameObject craftingTrophyPrefab;
    [SerializeField] private GameObject miscTrophyPrefab;

    private void Start()
    {
        achievementManager.Initialize();

        foreach (Achievement achievement in achievementManager.achievements)
        {
            switch (achievement.achievementType)
            {
                case AchievementType.Forge:
                    GameObject trophy = Instantiate(forgeTrophyPrefab, forgeTrophies.transform);
                    trophy.GetComponent<Image>().sprite = achievement.lockedSprite;
                    trophy.GetComponent<AchievementHolder>().achievement = achievement;
                    break;
                case AchievementType.Crafting:
                    trophy = Instantiate(craftingTrophyPrefab, craftingTrophies.transform);
                    trophy.GetComponent<Image>().sprite = achievement.lockedSprite;
                    trophy.GetComponent<AchievementHolder>().achievement = achievement;
                    break;
                case AchievementType.Misc:
                    trophy = Instantiate(miscTrophyPrefab, miscTrophies.transform);
                    trophy.GetComponent<Image>().sprite = achievement.lockedSprite;
                    trophy.GetComponent<AchievementHolder>().achievement = achievement;
                    break;
            }
        }
    }

    private void Update()
    {
        foreach (Achievement achievement in achievementManager.achievements)
        {
            if (achievement.isUnlocked && !unlocked.Contains(achievement))
            {
                GameObject temp = Instantiate(achievementUnlockedPrefab, achievementUnlockedPrefabParent.transform);
                achievementUnlocked = temp.GetComponent<AchievementUnlocked>();
                achievementUnlocked.achievement = achievement;
                unlocked.Add(achievement);
            }
        }
    }

    public void ProgressAchievement(string title, float amount)
    {
        Achievement achievement = achievementManager.achievements.Find(a => a.title == title);

        if (achievement != null)
        {
            achievement.IncrementProgress(amount);
        }
        else
        {
            Debug.Log("Achievement " + title + " not found");
        }
    }

    public void SetProgress(string title, float amount)
    {
        Achievement achievement = achievementManager.achievements.Find(a => a.title == title);

        if (achievement != null)
        {
            achievement.SetProgress(amount);
        }
        else
        {
            Debug.Log("Achievement " + title + " not found");
        }
    }
}
