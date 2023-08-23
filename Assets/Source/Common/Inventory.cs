using System;
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
    private void FixedUpdate()
    {
        ResourcesTypeContructor();
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

    private void ResourcesTypeContructor()
    {
        Dictionary<ResourceType, int> resourceCounts = new Dictionary<ResourceType, int>();
        for (int i = 0; i < resources.Count; i++)
        {
            ResourceType type = resources[i].Type;
            if (!resourceCounts.ContainsKey(type))
            {
                resourceCounts[type] = 0;
            }

            resourceCounts[type]++;
        }
        foreach(KeyValuePair<ResourceType, int> kvp in resourceCounts)
        {
            Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }
}
 