using UnityEditor;
using UnityEngine;
using Zenject;

public class ResourceFactory : MonoBehaviour
{
    public GameObject resourcePrefab;
    public Transform parentObject;
    public Transform[] spawnPlatform; 
    public float generationInterval = 5f; 
    public int maxResourcesOnPlatform = 10;

   
    private Vector3 platformMinPoint;
    private Vector3 platformMaxPoint;

    private int currentResourcesOnPlatform = 0;

    public bool isStarterFactory;

    private void Start()
    {
        spawnPlatform = parentObject.GetComponentsInChildren<Transform>();
        if (isStarterFactory == true) InvokeRepeating("GenerateResources", 1.5f, generationInterval);
    }

    public void GenerateResources()
    {
        if (currentResourcesOnPlatform >= maxResourcesOnPlatform)
        {
            return; // Достигнуто максимальное количество ресурсов на платформе
        }
        int randomindex = Random.Range(0, spawnPlatform.Length);

        Instantiate(resourcePrefab, spawnPlatform[randomindex].position, Quaternion.identity);
        currentResourcesOnPlatform++;
    }
}
