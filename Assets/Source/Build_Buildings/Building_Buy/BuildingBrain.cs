using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingBrain : MonoBehaviour
{
    public BuildingsPrice buildingPrices;
    private ResourceCount _resourceCount;
    private Inventory _inventory;
    [Inject]
    private void Contruct(Inventory inventory, ResourceCount resourceCount)
    {
        _resourceCount = resourceCount;
        _inventory = inventory;
        Debug.Log(_inventory + "Succesfully injected");
        Debug.Log(_resourceCount + "Succesfully injected");
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
        if (type == BuildingType.GoldFactorty)
        {
            int resourcesToRemove = 0; 
           
            for (int i = 0; i < _inventory.resources.Count; i++)
            {
                if (_inventory.resources[i].Type == ResourceType.Copper)
                {
                    resourcesToRemove++;
                    if (resourcesToRemove >= requiredAmount)
                    {
                        break; 
                    }
                }
            }

            if (resourcesToRemove >= requiredAmount)
            {
                _inventory.resources.RemoveRange(0, requiredAmount);
                return true;
            }
        }
        return false;
    }


}
//for (int i = 0; i < _inventory.resources.Count; i++)
//{
//    if (_inventory.resources[i].Type == ResourceType.Copper)
//    {
//        CountIterration++;
//    }
//}
//if (_inventory.resources.Count == 0)
//{
//    Debug.Log("У тебя инвентарь пустой лох");
//    return false;
//}

//private bool CheckResourceAvailability(ResourceType resourceType, int requiredAmount, BuildingType type)
//{
//    if (type == BuildingType.GoldFactorty)
//    {
//        if (resourceType == ResourceType.Copper && _resourceCount.CopperCount >= requiredAmount)
//        {
//            for (int i = 0; i < _inventory.resources.Count; i++)
//            {
//                if (_inventory.resources[i].Type == ResourceType.Copper)
//                {
//                    _inventory.resources.RemoveRange(0, requiredAmount);
//                }
//            }
//            return true;
//        }

//    }
//    return false;
//}