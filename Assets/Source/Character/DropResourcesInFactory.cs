using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class DropResourcesInFactory : MonoBehaviour
{
    [SerializeField] private Factory currentFactory;
    private Inventory inventory;
    [SerializeField]private bool inTrigger = false;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerStay(Collider other)
    {
        var factory = other.GetComponentInParent<Factory>();
        currentFactory = factory;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("Anroid");
            
            inTrigger = true;   
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                if (factory != null)
                {
                    if (factory.isCopperFactory == true && ChekingResourcesType())
                    {
                        foreach (var resource in inventory.Resources)
                        {
                            factory.Inventory.AddResource(resource);
                        }
                        inventory.Clear();
                    }
                    if (factory.isDuralFactory)
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
    }
    public void DropResources()
    {
        if (currentFactory == null) Debug.Log("U are not in Factory Trigger"); 
        if (currentFactory != null)
        {
            if (currentFactory.isCopperFactory == true && ChekingResourcesType())
            {
                foreach (var resource in inventory.Resources)
                {
                    currentFactory.Inventory.AddResource(resource);
                }
                inventory.Clear();
            }
            if (currentFactory.isDuralFactory)
            {
                foreach (var resource in inventory.Resources)
                {
                    currentFactory.Inventory.AddResource(resource);
                }
                inventory.Clear();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        currentFactory = null;  
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
