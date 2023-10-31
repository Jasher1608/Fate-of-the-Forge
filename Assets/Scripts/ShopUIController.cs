using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIController : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;

    [Header("Iron Bar")]
    [SerializeField] private Generator ironBar;
    [SerializeField] private Slider ironBarSlider;
    [SerializeField] private TextMeshProUGUI ironBarSellAmountText;
    [SerializeField] private TextMeshProUGUI ironBarMaxText;
    [SerializeField] private TextMeshProUGUI ironBarSellValueText;

    [Header("Silver Bar")]
    [SerializeField] private Generator silverBar;
    [SerializeField] private Slider silverBarSlider;
    [SerializeField] private TextMeshProUGUI silverBarSellAmountText;
    [SerializeField] private TextMeshProUGUI silverBarMaxText;
    [SerializeField] private TextMeshProUGUI silverBarSellValueText;

    [Header("Gold Bar")]
    [SerializeField] private Generator goldBar;
    [SerializeField] private Slider goldBarSlider;
    [SerializeField] private TextMeshProUGUI goldBarSellAmountText;
    [SerializeField] private TextMeshProUGUI goldBarMaxText;
    [SerializeField] private TextMeshProUGUI goldBarSellValueText;

    private void Update()
    {
        ironBarSellAmountText.text = ironBarSlider.value.ToString("#,0");
        silverBarSellAmountText.text = silverBarSlider.value.ToString("#,0");
        goldBarSellAmountText.text = goldBarSlider.value.ToString("#,0");

        ironBarSellValueText.text = "$" + (ironBarSlider.value * ironBar.value * ShopController.barPriceMultiplier).ToString("#,0.00");
        silverBarSellValueText.text = "$" + (silverBarSlider.value * silverBar.value * ShopController.barPriceMultiplier).ToString("#,0.00");
        goldBarSellValueText.text = "$" + (goldBarSlider.value * goldBar.value * ShopController.barPriceMultiplier).ToString("#,0.00");
    }

    public void UpdateSeller()
    {
        // Text
        ironBarMaxText.text = InventoryManager.ironBars.ToString("#,0");
        silverBarMaxText.text = InventoryManager.silverBars.ToString("#,0");
        goldBarMaxText.text = InventoryManager.goldBars.ToString("#,0");
        // Slider max values
        ironBarSlider.maxValue = InventoryManager.ironBars;
        silverBarSlider.maxValue = InventoryManager.silverBars;
        goldBarSlider.maxValue = InventoryManager.goldBars;
    }
}
