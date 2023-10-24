using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;
    
    [SerializeField] private GeneratorMono ironBar;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI ironBarText;
    [SerializeField] private TextMeshProUGUI ironBarOwnedText;

    [SerializeField] private Slider clickSlider;

    private void Start()
    {
        UpdateMoney();
        UpdatePurchased();
        UpdateOwned();
    }

    public void UpdateMoney()
    {
        moneyText.text = "$" + Mathf.Round((float)(InventoryManager.money * 100.0)) / 100.0; // Rounds to 2dp
    }

    public void UpdatePurchased()
    {
        ironBarText.text = "Purchased: " + ironBar._quantity;
    }

    public void UpdateOwned()
    {
        ironBarOwnedText.text = "Owned: " + InventoryManager.ironBars;
    }

    public void UpdateClickSlider()
    {
        clickSlider.maxValue = inventory.clickTime; // Move this eventually, calling this every frame while running is not optimal
        clickSlider.value = inventory.clickTimeProgress;
    }
}
