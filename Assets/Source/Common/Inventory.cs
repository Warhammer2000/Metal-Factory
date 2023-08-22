using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ResourceData> resources;

    public List<ResourceData> resourceDural;

    public IReadOnlyList<ResourceData> Resources => resources.AsReadOnly();
    private  int InventoryItemsCount => resources.Count;

    private void Awake()
    {
        resources = new List<ResourceData>(32);
    }

    public void AddResource(ResourceData data)
    {
        resources.Add(data);

        resourceDural.Add(data);

        for (int i = 0; i < resourceDural.Count; i++)
        {
            if (resourceDural[i].Type == ResourceType.Copper || resourceDural[i].Type == ResourceType.Iron)
            {
                resourceDural.RemoveAt(i);
            }
        }
        for(int i = 0; i < resources.Count; i++)
        {
            if (resources[i].Type == ResourceType.Dural)
            {
                resources.RemoveAt(i);  
            }
        }
    }
    public void RemoveResource(ResourceData data) => resources.Remove(data);
    public void Clear() => resources.Clear();
}
//public void CheckItems()
//{
//    if (resources.Count >= 10)
//    {
//        if (_factory.isDuralFactory == true)
//        {
//            if (CheckingResources())
//            {
//                Debug.Log("Uspex");
//                Dictionary<ResourceType, int> resourceCounts = new Dictionary<ResourceType, int>();
//                for (int i = 0; i < resources.Count; i++)
//                {
//                    ResourceType type = resources[i].Type;
//                    if (!resourceCounts.ContainsKey(type))
//                    {
//                        resourceCounts[type] = 0;
//                    }
//                    Debug.Log("Uspex0");
//                    resourceCounts[type]++;
//                }
//                bool hasIron = resourceCounts.ContainsKey(ResourceType.Iron);
//                bool hasCopper = resourceCounts.ContainsKey(ResourceType.Copper);
//                if (hasIron && hasCopper)
//                {
//                    _resfactory.GenerateResources(resources.Count);
//                }



//            }
//            else Debug.Log("ne Uspex");
//        }
//        else _resfactory.GenerateResources(resources.Count);
//    }
//}
//private bool CheckingResources()
//{
//    for(int i = 0; i < resources.Count; i++)
//    {
//        if (resources[i].Type == ResourceType.Iron && resources[i].Type == ResourceType.Copper)
//        Debug.Log(resources[i].Type == ResourceType.Iron && resources[i].Type == ResourceType.Copper);
//        return true;
//    }
//    return false;
//}