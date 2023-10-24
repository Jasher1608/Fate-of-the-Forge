using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorMono : MonoBehaviour
{
    [SerializeField] Generator generator;
    [SerializeField] private Slider milestoneProgress;

    public int _quantity;
    public float buyPrice;

    private int nextMilestone;
    private int lastMilestone = 0;

    private void Start()
    {
        CalculateNext();
        CalculateNextMilestone();
        _quantity = generator.quantity;
        milestoneProgress.maxValue = nextMilestone;
        milestoneProgress.value = _quantity;
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
            milestoneProgress.value = _quantity;
            if (_quantity >= nextMilestone && nextMilestone != 400)
            {
                CalculateNextMilestone();
                milestoneProgress.maxValue = nextMilestone;
                milestoneProgress.minValue = lastMilestone;
            }
        }
    }

    public void CalculateNext()
    {
        buyPrice = generator.baseBuyPrice * Mathf.Pow(generator.priceGrowth, _quantity);
    }

    private void CalculateNextMilestone()
    {
        if (_quantity >= 0 && _quantity < 25)
        {
            nextMilestone = 25;
            lastMilestone = 0;
        }
        else if (_quantity >= 25 && _quantity < 50)
        {
            nextMilestone = 50;
            lastMilestone = 25;
        }
        else if (_quantity >= 50 && _quantity < 100)
        {
            nextMilestone = 100;
            lastMilestone = 50;
        }
        else if (_quantity >= 100 && _quantity < 200)
        {
            nextMilestone = 200;
            lastMilestone = 100;
        }
        else if (_quantity >= 200 && _quantity < 400)
        {
            nextMilestone = 400;
            lastMilestone = 200;
        }
    }
}
