using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMono : MonoBehaviour
{
    [SerializeField] Generator generator;

    public int _quantity;
    public float buyPrice;

    private void Start()
    {
        _quantity = generator.quantity;
    }

    public bool CanUpgrade()
    {
        if (InventoryManager.money >= buyPrice)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Upgrade()
    {
        if (CanUpgrade())
        {
            _quantity += 1;
            InventoryManager.money -= buyPrice;
            CalculateNext();
        }
    }

    public void CalculateNext()
    {
        buyPrice = generator.baseBuyPrice * Mathf.Pow(generator.priceGrowth, _quantity);
    }
}
