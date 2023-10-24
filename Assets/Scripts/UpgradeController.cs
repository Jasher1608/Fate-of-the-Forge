using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private List<GeneratorMono> generators = new List<GeneratorMono>();

    [SerializeField] private GeneratorMono ironBar;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI ironBarText;

    private void Start()
    {
        foreach (GeneratorMono generator in generators)
        {
            generator.CalculateNext();
        }
        Instantiate(ironBar);
    }

    private void Update()
    {
        ironBarText.text = "Purchased: " + ironBar._quantity;
        moneyText.text = "$" + InventoryManager.money;
    }

    public void Upgrade(GeneratorMono generator)
    {
        if (generator.CanUpgrade())
        {
            generator.Upgrade();
        }
    }
}
