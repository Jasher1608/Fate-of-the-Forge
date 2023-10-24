using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GeneratorMono> generators = new List<GeneratorMono>();
    
    public static double money = 1000; // Using double to allow player to have more money
    public static int ironBars = 0;
    public static int silverBars = 0;
    public static int goldBars = 0;

    public void Produce()
    {
        foreach (GeneratorMono generator in generators)
        {
            generator.Produce();
        }
    }
}
