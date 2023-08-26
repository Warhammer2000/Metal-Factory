using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class FactoryInventory : MonoBehaviour
{
    public List<ResourceData> resources { get;  set; }
    private ResourceFactory _resfactory;
    private Factory _factory; 
    private IReadOnlyList<ResourceData> Resources => resources.AsReadOnly();
    private int InventoryItemsCount => resources.Count;

    
    private void Awake()
    {
        _factory = GetComponent<Factory>();
        resources = new List<ResourceData>(32);
        _resfactory = GetComponent<ResourceFactory>();
    }
    private void FixedUpdate()
    {
       CheckItems();
    }
    public void CheckItems()
    {
        if (resources.Count >= 10)
        {
            if (_factory.isDuralFactory == true)
            {
                if (CheckingResources())
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
                    bool hasIron = resourceCounts.ContainsKey(ResourceType.Iron);
                    bool hasCopper = resourceCounts.ContainsKey(ResourceType.Copper);
                    bool hasDural = resourceCounts.ContainsKey(ResourceType.Dural);
                    if (!hasDural && hasIron && hasCopper)
                    {
                        Debug.Log("Производство");
                        ProduceDural(_factory);
                        return;
                    }
                }
            }
            else _resfactory.GenerateResources(resources.Count);
        }
    }
    private bool CheckingResources()
    {
#pragma warning disable CS0162 // Обнаружен недостижимый код
        for (int i = 0; i < resources.Count; i++)
        {
            if (resources[i].Type == ResourceType.Iron && resources[i].Type == ResourceType.Copper)
            Debug.Log(resources[i].Type == ResourceType.Iron && resources[i].Type == ResourceType.Copper);
            return true;
        }
#pragma warning restore CS0162 // Обнаружен недостижимый код
        return false;
    }
    private void ProduceDural(Factory factory)
    {
        int ironCount = 0;
        int copperCount = 0;

        foreach (var resource in resources)
        {
            if (resource.Type == ResourceType.Iron)
            {
                ironCount++;
            }
            else if (resource.Type == ResourceType.Copper)
            {
                copperCount++;
            }
        }

        if (ironCount >= 10 && copperCount >= 10)
        {
            // Производство Dural
            int duralToProduce = Math.Min(ironCount, copperCount); // Выбираем минимальное количество из ironCount и copperCount
            _resfactory.GenerateResources(resources.Count);
            StartCoroutine(WaitProduce());
        }
    }
    private IEnumerator WaitProduce()
    {
        yield return new WaitForSeconds(1f);
        Clear();
    }
    public void AddResource(ResourceData data) => resources.Add(data);
  
    public void RemoveResource(ResourceData data) => resources.Remove(data);
    public void Clear() => resources.Clear();
}
