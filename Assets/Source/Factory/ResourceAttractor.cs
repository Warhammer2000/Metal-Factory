using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAttractor : MonoBehaviour
{
    public float attractionSpeed = 5f;

    private void OnTriggerStay(Collider other)
    {
        Resource resource = other.GetComponent<Resource>();
        if (resource != null)
        {
            Vector3 directionToPlayer = transform.parent.position - resource.transform.position;
            resource.rb.AddForce(directionToPlayer.normalized * attractionSpeed);
        }
    }
}
