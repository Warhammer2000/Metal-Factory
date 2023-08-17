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

    private void OnTriggerEnter(Collider other)
    {
        var factory = other.GetComponentInParent<Factory>();

        if (factory != null)
        {
            foreach (var r in inventory.Resources)
            {
                factory.Inventory.AddResource(r);
            }
            inventory.Clear();
        }
    }
}
