using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingPrices", menuName = "Custom/Building Prices")]
public class BuildingsPrice : ScriptableObject
{
    public BuildingCost[] data;
}
