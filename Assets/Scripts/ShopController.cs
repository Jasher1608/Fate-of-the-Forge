using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    [SerializeField] ShopUIController shopUIController;
    [SerializeField] UIController UIController;
    
    [SerializeField] Generator generator;

    public float barPriceMultiplier = 1f;

    public SellingType sellingType;

    [SerializeField] private Slider slider;

    public void Sell()
    {
        switch (sellingType)
        {
            case SellingType.Iron:
                InventoryManager.ironBars -= (int) slider.value;
                InventoryManager.money += (slider.value * generator.value) * barPriceMultiplier;
                slider.value = 0;
                break;
            case SellingType.Silver:
                InventoryManager.silverBars -= (int)slider.value;
                InventoryManager.money += (slider.value * generator.value) * barPriceMultiplier;
                slider.value = 0;
                break;
            case SellingType.Gold:
                InventoryManager.goldBars -= (int)slider.value;
                InventoryManager.money += (slider.value * generator.value) * barPriceMultiplier;
                slider.value = 0;
                break;
        }
        shopUIController.UpdateSliders();
        UIController.UpdateOwned();
        UIController.UpdateMoney();
    }
}

public enum SellingType
{
    Iron,
    Silver,
    Gold
}
