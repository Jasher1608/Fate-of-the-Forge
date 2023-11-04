using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AchievementHolder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Achievement achievement;

    private AchievementSystem achievementSystem;

    private GameObject tooltip;
    private TextMeshProUGUI title;
    private TextMeshProUGUI description;

    private void Start()
    {
        achievementSystem = GameObject.FindWithTag("Manager").GetComponent<AchievementSystem>();
    }

    private void Update()
    {
        if (achievement.isUnlocked)
        {
            GetComponent<Image>().sprite = achievement.unlockedSprite;
        }

        if (tooltip != null)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip = Instantiate(achievementSystem.tooltipPrefab, this.transform.parent.transform.parent.transform.parent.transform.parent.transform);
        title = tooltip.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        description = tooltip.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        title.text = achievement.title;
        description.text = achievement.description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(tooltip);
    }
}
