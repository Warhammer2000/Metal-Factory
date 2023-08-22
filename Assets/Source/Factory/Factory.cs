using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FactoryInventory))]
public class Factory : MonoBehaviour
{
    public FactoryInventory Inventory { get; set; }
    public bool isCopperFactory;
    public bool isDuralFactory;
    private void Awake()
    {
        Inventory = GetComponent<FactoryInventory>();
    }
}
