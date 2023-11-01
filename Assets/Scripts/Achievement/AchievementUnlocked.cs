using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementUnlocked : MonoBehaviour
{
    public Achievement achievement;
    
    [SerializeField] private TextMeshProUGUI titleText;

    private void Start()
    {
        titleText.text = achievement.title.ToString();
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
