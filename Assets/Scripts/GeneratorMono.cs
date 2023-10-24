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
        int[] milestones = { 0, 25, 50, 100, 200, 400 };

        for (int i = 1; i < milestones.Length; i++)
        {
            if (_quantity >= milestones[i - 1] && _quantity < milestones[i])
            {
                nextMilestone = milestones[i];
                lastMilestone = milestones[i - 1];
                return;
            }
        }
    }
}
