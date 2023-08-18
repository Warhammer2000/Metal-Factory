using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour
{
    public List<ResourceData> resources;
    private ResourceFactory _factory;
    public IReadOnlyList<ResourceData> Resources => resources.AsReadOnly();
    public int InventoryItemsCount => resources.Count;

    public bool isFactory;
    private void Awake()
    {
        resources = new List<ResourceData>(32);
        if(isFactory == true) _factory = GetComponent<ResourceFactory>();
    }
    private void FixedUpdate()
    {
        Debug.Log(resources.Count);
        if (isFactory == true) CheckItems();
    }
    public void CheckItems()
    {
        if (resources.Count >= 10)
        {
            _factory.GenerateResources();
        }
    }
    public void AddResource(ResourceData data) => resources.Add(data);
    public void RemoveResource(ResourceData data) => resources.Remove(data);
    public void Clear() => resources.Clear();
}
