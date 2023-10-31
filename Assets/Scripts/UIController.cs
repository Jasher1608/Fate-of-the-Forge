using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private ShopUIController shopUIController;

    [Header("Iron Bar")]
    [SerializeField] private GeneratorMono ironBar;
    [SerializeField] private TextMeshProUGUI ironBarText;
    [SerializeField] private TextMeshProUGUI ironBarOwnedText;

    [Header("Silver Bar")]
    [SerializeField] private GeneratorMono silverBar;
    [SerializeField] private TextMeshProUGUI silverBarText;
    [SerializeField] private TextMeshProUGUI silverBarOwnedText;

    [Header("Gold Bar")]
    [SerializeField] private GeneratorMono goldBar;
    [SerializeField] private TextMeshProUGUI goldBarText;
    [SerializeField] private TextMeshProUGUI goldBarOwnedText;

    [Header("Other UI")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Slider clickSlider;

    private void Start()
    {
        UpdateMoney();
        UpdatePurchased();
        UpdateOwned();
    }

    public void UpdateMoney()
    {
        moneyText.text = "$" + (Mathf.Round((float)(InventoryManager.money * 100.0)) / 100.0).ToString("#,0.00"); // Rounds to 2dp
    }

    public void UpdatePurchased()
    {
        ironBarText.text = "Purchased: " + ironBar._quantity.ToString("#,0");
        silverBarText.text = "Purchased: " + silverBar._quantity.ToString("#,0");
        goldBarText.text = "Purchased: " + goldBar._quantity.ToString("#,0");
    }

    public void UpdateOwned()
    {
        ironBarOwnedText.text = "Owned: " + InventoryManager.ironBars.ToString("#,0");
        silverBarOwnedText.text = "Owned: " + InventoryManager.silverBars.ToString("#,0");
        goldBarOwnedText.text = "Owned: " + InventoryManager.goldBars.ToString("#,0");
        shopUIController.UpdateSeller();
    }

    public void UpdateClickSlider()
    {
        clickSlider.maxValue = inventory.clickTime; // Move this eventually, calling this every frame while running is not optimal
        clickSlider.value = inventory.clickTimeProgress;
    }
}
