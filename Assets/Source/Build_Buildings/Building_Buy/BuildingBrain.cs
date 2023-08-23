using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBrain : MonoBehaviour
{
    public BuildingsPrice buildingPrices;
    private void Awake()
    {
        CanBuildBuilding(buildingPrices);
    }
    public bool CanBuildBuilding(BuildingsPrice price)
    {
        foreach (BuildingCost cost in price.data)
        {
            if (!CheckResourceAvailability(cost.resourceType, cost.amount, cost.buildingType))
            {
                return false;
            }
        }
        Debug.Log("Finnaly Uspex");
        return true;
    }

    private bool CheckResourceAvailability(ResourceType resourceType, int requiredAmount, BuildingType type)
    {
        if(type == BuildingType.GoldFactorty)
        {
            if (resourceType == ResourceType.Copper && requiredAmount >= 10)
            {
                Debug.Log("True");
                return true;
            }
        }
        return false;
    }
}
