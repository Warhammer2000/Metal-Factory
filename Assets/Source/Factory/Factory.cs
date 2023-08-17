using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Factory : MonoBehaviour
{
    public Inventory Inventory { get; private set; }

    private void Awake()
    {
        Inventory = GetComponent<Inventory>();
    }
}
