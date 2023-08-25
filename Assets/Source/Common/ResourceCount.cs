using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCount : MonoBehaviour
{
    private Inventory inventory;

    [field : SerializeField] public int IronCount { get; private set; } = 0;
    [field: SerializeField] public int CopperCount { get; private set; } = 0;
    [field: SerializeField] public int DuralCount { get; private set; } = 0;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    private void Update()
    {
        GetResourcesCountAndType();

    }
    public void GetResourcesCountAndType()
    {
        int ironCount = 0;
        int copperCount = 0;
        int duralCount = 0;

       
        for (int i = 0; i < inventory.resources.Count; i++)
        {
            if (inventory.resources[i].Type == ResourceType.Iron)
            {
                ironCount += inventory.resources[i].Amount;
            }
            if (inventory.resources[i].Type == ResourceType.Copper)
            {
                copperCount += inventory.resources[i].Amount;
            }
        }
        for (int i = 0; i < inventory.resourceDural.Count; i++)
        {
            if (inventory.resourceDural[i].Type == ResourceType.Dural)
            {
                duralCount += inventory.resourceDural[i].Amount;
            }
        }
        IronCount = ironCount;
        CopperCount = copperCount;
        DuralCount = duralCount;    
    }
}
