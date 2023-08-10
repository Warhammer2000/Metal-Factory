using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ResourceAttractor : MonoBehaviour
{
    [field: SerializeField] public float attractionSpeed { get; private set; } = 5f;
    public Transform[] casePos;
    private void OnTriggerStay(Collider other)
    {
        Resource resource = other.GetComponent<Resource>();
        int randomIndex = Random.Range(0, casePos.Length);  
        if (resource != null)
        {
            Vector3.MoveTowards(other.transform.position, casePos[randomIndex].position, attractionSpeed);
        }
        //if(alredypassed)
        //{
        //    other.transform.position = casePos[randomIndex].position;   
        //}
    }
}
