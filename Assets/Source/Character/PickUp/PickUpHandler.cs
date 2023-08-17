using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour
{
    private PickUpDetector detector;
    private Inventory inventory;


    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        detector = GetComponent<PickUpDetector>();
    }

    private void Start()
    {
        detector.OnPickUp += OnPickUpHandler;
    }

    private void OnPickUpHandler(ResourceData resource)
    {
        inventory.AddResource(resource);
    }
}
