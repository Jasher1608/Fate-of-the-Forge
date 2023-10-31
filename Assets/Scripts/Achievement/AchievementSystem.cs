using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour
{
    public AchievementManager achievementManager;

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

        ProgressAchivement("Forging a new beginning", 1);
    }

    public void ProgressAchivement(string title, float amount)
    {
        Achievement achievement = achievementManager.achievements.Find(a => a.title == title);

        if (achievement != null)
        {
            achievement.IncrementProgress(amount);
        }
    }
}
