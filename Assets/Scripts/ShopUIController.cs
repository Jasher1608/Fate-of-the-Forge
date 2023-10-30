using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIController : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;

    [Header("Iron Bar")]
    [SerializeField] private Slider ironBarSlider;
    [SerializeField] private TextMeshProUGUI ironBarSellAmountText;
    [SerializeField] private TextMeshProUGUI ironBarMaxText;

    [Header("Silver Bar")]
    [SerializeField] private Slider silverBarSlider;
    [SerializeField] private TextMeshProUGUI silverBarSellAmountText;
    [SerializeField] private TextMeshProUGUI silverBarMaxText;

    [Header("Gold Bar")]
    [SerializeField] private Slider goldBarSlider;
    [SerializeField] private TextMeshProUGUI goldBarSellAmountText;
    [SerializeField] private TextMeshProUGUI goldBarMaxText;

    private void Update()
    {
        ironBarSellAmountText.text = ironBarSlider.value.ToString("#,0");
        silverBarSellAmountText.text = silverBarSlider.value.ToString("#,0");
        goldBarSellAmountText.text = goldBarSlider.value.ToString("#,0");
    }

    public void UpdateSliders()
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
