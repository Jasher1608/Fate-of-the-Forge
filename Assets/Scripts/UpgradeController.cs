using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private GeneratorMono ironBar;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI ironBarText;

    private void Update()
    {
        ironBarText.text = "Purchased: " + ironBar._quantity;
        moneyText.text = "$" + Mathf.Round((float)(InventoryManager.money * 100.0)) / 100.0; // Rounds to 2dp
    }

    public void Upgrade(GeneratorMono generator)
    {
        if (generator.CanUpgrade())
        {
            generator.Upgrade();
        }
    }
}
