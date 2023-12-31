using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneratorMono : MonoBehaviour
{
    [SerializeField] private AchievementSystem achievementSystem;
    
    [SerializeField] Generator generator;
    [SerializeField] private Slider milestoneProgress;

    [SerializeField] private TextMeshProUGUI costText;

    [SerializeField] private UIController UIController;

    [SerializeField] private Button buyOne;
    [SerializeField] private Button buyTen;
    [SerializeField] private Button buyHundred;

    [SerializeField] private GameObject lockSprite;
    private Animator animationComponent;

    private int purchaseAmount = 1;

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

        animationComponent = lockSprite.GetComponent<Animator>();

        // Achievements
        achievementSystem.SetProgress("Forging a new beginning", 1);
        achievementSystem.SetProgress("Ironcraft Initiate", 1);
        achievementSystem.SetProgress("Hundredfold Hammering", 1);
        achievementSystem.SetProgress("Double down on iron", 1);
        achievementSystem.SetProgress("Metallurgic Mastermind", 1);
    }

    private void Update()
    {
        // Achievements
        switch (generatorType)
        {
            case GeneratorType.Iron:
                achievementSystem.SetProgress("Forging a new beginning", _quantity);
                achievementSystem.SetProgress("Ironcraft Initiate", _quantity);
                achievementSystem.SetProgress("Hundredfold Hammering", _quantity);
                achievementSystem.SetProgress("Double down on iron", _quantity);
                achievementSystem.SetProgress("Metallurgic Mastermind", _quantity);
                break;
            case GeneratorType.Copper:
                achievementSystem.SetProgress("Bronze Beginnings", _quantity);
                achievementSystem.SetProgress("Cuprum Collector", _quantity);
                achievementSystem.SetProgress("Copper Centurion", _quantity);
                achievementSystem.SetProgress("Copper Cascade", _quantity);
                achievementSystem.SetProgress("Copper Crescendo", _quantity);
                break;
            case GeneratorType.Silver:
                achievementSystem.SetProgress("Silvery step forward", _quantity);
                achievementSystem.SetProgress("Fifty Shades of Silver", _quantity);
                achievementSystem.SetProgress("Silverado", _quantity);
                achievementSystem.SetProgress("Silver Surplus", _quantity);
                achievementSystem.SetProgress("Argentum Anarchy", _quantity);
                break;
            case GeneratorType.Gold:
                achievementSystem.SetProgress("Gold Rush", _quantity);
                achievementSystem.SetProgress("Gilded Grandeur", _quantity);
                achievementSystem.SetProgress("Gold Gregg", _quantity);
                achievementSystem.SetProgress("Aurum Abundance", _quantity);
                achievementSystem.SetProgress("The Midas Touch", _quantity);
                break;
        }
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
            if (_quantity == 0)
            {
                animationComponent.SetTrigger("Unlock");
                Destroy(lockSprite, 1.1f);
            }
            
            _quantity += purchaseAmount;
            UIController.UpdatePurchased();
            production = Mathf.FloorToInt((generator.baseProduction * _quantity) * productionMultiplier);
            InventoryManager.money -= buyPrice;
            UIController.UpdateMoney();
            CalculateNext();
            if (_quantity >= nextMilestone && nextMilestone != 400)
            {
                CalculateNextMilestone();
                milestoneProgress.maxValue = nextMilestone;
                milestoneProgress.minValue = lastMilestone;
            }
            milestoneProgress.value = _quantity;
        }
    }

    public void CalculateNext()
    {
        if (buyOne.gameObject.activeSelf)
        {
            buyPrice = generator.baseBuyPrice * Mathf.Pow(generator.priceGrowth, _quantity);
            purchaseAmount = 1;
        }
        else if (buyTen.gameObject.activeSelf)
        {
            float numerator = Mathf.Pow(generator.priceGrowth, _quantity) * (Mathf.Pow(generator.priceGrowth, 10) - 1);
            float denominator = generator.priceGrowth - 1;
            buyPrice = generator.baseBuyPrice * (numerator / denominator);
            purchaseAmount = 10;
        }
        else if (buyHundred.gameObject.activeSelf)
        {
            float numerator = Mathf.Pow(generator.priceGrowth, _quantity) * (Mathf.Pow(generator.priceGrowth, 100) - 1);
            float denominator = generator.priceGrowth - 1;
            buyPrice = generator.baseBuyPrice * (numerator / denominator);
            purchaseAmount = 100;
        }

        costText.text = "$" + (Mathf.Round((float)(buyPrice * 100.0)) / 100.0).ToString("#,0.00");
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
            case GeneratorType.Copper:
                InventoryManager.copperBars += production;
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
    Copper,
    Silver,
    Gold
}