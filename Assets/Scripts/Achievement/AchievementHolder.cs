using UnityEngine;
using UnityEngine.UI;

public class AchievementHolder : MonoBehaviour
{
    public Achievement achievement;

    private void Update()
    {
        if (achievement.isUnlocked)
        {
            GetComponent<Image>().sprite = achievement.unlockedSprite;
        }
    }
}
