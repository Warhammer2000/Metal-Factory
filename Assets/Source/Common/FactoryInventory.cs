using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FactoryInventory : MonoBehaviour
{
    public List<ResourceData> resources;

    private ResourceFactory _resfactory;
    private Factory _factory; 
    public IReadOnlyList<ResourceData> Resources => resources.AsReadOnly();
    public int InventoryItemsCount => resources.Count;

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
                        _resfactory.GenerateResources(resources.Count);
                        return;
                    }
                }
            }
            else _resfactory.GenerateResources(resources.Count);
        }
    }
    private bool CheckingResources()
    {
        for(int i = 0; i < resources.Count; i++)
        {
            if (resources[i].Type == ResourceType.Iron && resources[i].Type == ResourceType.Copper)
            Debug.Log(resources[i].Type == ResourceType.Iron && resources[i].Type == ResourceType.Copper);
            return true;
        }
        return false;
    }
    public void AddResource(ResourceData data) => resources.Add(data);
  
    public void RemoveResource(ResourceData data) => resources.Remove(data);
    public void Clear() => resources.Clear();
}
