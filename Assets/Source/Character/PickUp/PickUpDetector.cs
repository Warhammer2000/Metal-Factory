using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetector : MonoBehaviour
{
    public Action<ResourceData> OnPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Resource>(out var resource))
        {
            OnPickUp?.Invoke(resource.Data);
            Destroy(resource.gameObject);
        }
    }
}
