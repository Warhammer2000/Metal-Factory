using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour
{
    public List<ResourceData> resources;
    private ResourceFactory _resfactory;
    private Factory _factory;
    public IReadOnlyList<ResourceData> Resources => resources.AsReadOnly();
    public int InventoryItemsCount => resources.Count;

    public bool isFactory;
    private void Awake()
    {
        _factory = GetComponent<Factory>();
        resources = new List<ResourceData>(32);
        if(isFactory == true) _resfactory = GetComponent<ResourceFactory>();
    }
    private void FixedUpdate()
    {
        if (isFactory == true) CheckItems();
    }
    public void CheckItems()
    {
        if (resources.Count >= 10)
        {
            if(_factory.isDuralFactory == true)
            {
                if (CheckingResources())
                {
                    Debug.Log("Uspex");
                    _resfactory.GenerateResources();
                }
                else Debug.Log("ne Uspex");
            }
            else _resfactory.GenerateResources();
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
