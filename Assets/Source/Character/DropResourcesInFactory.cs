using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class DropResourcesInFactory : MonoBehaviour
{
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerStay(Collider other)
    {
        var factory = other.GetComponentInParent<Factory>();

        if (Input.GetKey(KeyCode.R))
        {
            if (factory != null)
            {
                if (ChekingResourcesType())
                {
                    foreach (var resource in inventory.Resources)
                    {
                        factory.Inventory.AddResource(resource);
                    }
                    inventory.Clear();
                }
                
            }
        } 
    }
    private bool ChekingResourcesType()
    {
        for(int i = 0; i < inventory.resources.Count; i++)
        {
            if (inventory.resources[i].Type == ResourceType.Iron)
            return true;
        }
        return false;
    }
}
