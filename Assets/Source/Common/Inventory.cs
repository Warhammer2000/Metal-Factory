using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ResourceData> resources;

    public IReadOnlyList<ResourceData> Resources => resources.AsReadOnly();

    public int InventoryItemsCount => resources.Count;

    private void Awake()
    {
        resources = new List<ResourceData>(32);
    }

    public void AddResource(ResourceData data) => resources.Add(data);
    public void RemoveResource(ResourceData data) => resources.Remove(data);
    public void Clear() => resources.Clear();
}
