using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneratorMono : MonoBehaviour
{
    [SerializeField] Generator generator;
    [SerializeField] private Slider milestoneProgress;

    [SerializeField] private TextMeshProUGUI costText;

    [SerializeField] private UIController UIController;

    public GeneratorType generatorType;

    public int _quantity;
    public float buyPrice;
    public int production;
    public float productionMultiplier = 1f;

    private int nextMilestone;
    private int lastMilestone = 0;

    private void Start()
    {
        CalculateNext();
        CalculateNextMilestone();
        _quantity = generator.quantity;
        production = Mathf.FloorToInt((generator.baseProduction * _quantity) * productionMultiplier);
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
            UIController.UpdatePurchased();
            production = Mathf.FloorToInt((generator.baseProduction * _quantity) * productionMultiplier);
            InventoryManager.money -= buyPrice;
            UIController.UpdateMoney();
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
        costText.text = "$" + Mathf.Round((float)(buyPrice * 100.0)) / 100.0;
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
                
                // Production multiplier
                switch (i)
                {
                    case 1:
                        productionMultiplier = 1;
                        break;
                    case 2:
                        productionMultiplier = 1.25f;
                        break;
                    case 3:
                        productionMultiplier = 1.5f;
                        break;
                    case 4:
                        productionMultiplier = 1.75f;
                        break;
                    case 5:
                        productionMultiplier = 2;
                        break;
                    case 6:
                        productionMultiplier = 2.25f;
                        break;
                }
                production = Mathf.FloorToInt((generator.baseProduction * _quantity) * productionMultiplier);
                return;
            }
        }
    }

    public void Produce()
    {
        switch (generatorType)
        {
            case GeneratorType.Iron:
                InventoryManager.ironBars += production;
                break;
            case GeneratorType.Silver:
                InventoryManager.silverBars += production;
                break;
            case GeneratorType.Gold:
                InventoryManager.goldBars += production;
                break;
        }

        UIController.UpdateOwned();
    }
}

public enum GeneratorType
{
    Iron,
    Silver,
    Gold
}