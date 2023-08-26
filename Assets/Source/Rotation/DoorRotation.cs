using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Скорость поворота
    [SerializeField] private Quaternion targetRotation;
    [SerializeField] private Quaternion defaultRotation;
    private bool isOpen = false;

    [SerializeField] private float timer = 0.0f;
    public float delayInSeconds = 3.0f;

    private void Awake()
    {
        defaultRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, 200, 0);
    }

    private void Update()
    {
        if (!isOpen && timer < delayInSeconds)
        {
            timer += Time.deltaTime;
        }
        else if (!isOpen && timer >= delayInSeconds)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, defaultRotation, 15 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Inventory>())
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            isOpen = true;
            timer = 0.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Inventory>())
        {
            isOpen = false;
        }
    }
}
