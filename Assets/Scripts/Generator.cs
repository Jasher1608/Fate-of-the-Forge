using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Generator", menuName = "Generators/New Generator")]
public class Generator : ScriptableObject
{
    public int quantity = 0;
    public float baseBuyPrice;
    public float priceGrowth;
    public float baseProduction;

    public float buyPrice;
}
