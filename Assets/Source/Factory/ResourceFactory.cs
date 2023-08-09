using UnityEditor;
using UnityEngine;

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

    private void Start()
    {
        spawnPlatform = parentObject.GetComponentsInChildren<Transform>();
        InvokeRepeating("GenerateResources", 0f, generationInterval);
    }

    private void GenerateResources()
    {
        if (currentResourcesOnPlatform >= maxResourcesOnPlatform)
        {
            return; // Достигнуто максимальное количество ресурсов на платформе
        }
        int randomindex = Random.Range(0, spawnPlatform.Length);
        //Vector3 randomPosition = new Vector3(
        //    Random.Range(platformMinPoint.x, platformMaxPoint.x),
        //    platformMaxPoint.y,
        //    Random.Range(platformMinPoint.z, platformMaxPoint.z)
        //);

        Instantiate(resourcePrefab, spawnPlatform[randomindex].position, Quaternion.identity);
        currentResourcesOnPlatform++;
    }
}
