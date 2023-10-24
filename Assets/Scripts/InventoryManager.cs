using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GeneratorMono> generators = new List<GeneratorMono>();

    [SerializeField] private UIController UIController;
    
    public static double money = 1000; // Using double to allow player to have more money
    public static int ironBars = 0;
    public static int silverBars = 0;
    public static int goldBars = 0;

    public float clickTime;
    [HideInInspector] public float clickTimeProgress = 0f;
    private bool isProducing = false;

    private void Update()
    {
        if (isProducing)
        {
            clickTimeProgress += Time.deltaTime;
            UIController.UpdateClickSlider();
            Produce(); // Janky lmao
        }
    }

    public void Produce()
    {
        isProducing = true;
        if (clickTimeProgress >= clickTime)
        {
            foreach (GeneratorMono generator in generators)
            {
                generator.Produce();
                clickTimeProgress = 0f;
                isProducing = false;
                UIController.UpdateClickSlider();
            }
        }
    }
}
