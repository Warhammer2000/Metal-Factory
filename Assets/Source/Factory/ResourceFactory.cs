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

    private float timer = 0f;

    private Vector3 platformMinPoint;
    private Vector3 platformMaxPoint;

    private int currentResourcesOnPlatform = 0;

    public bool isStarterFactory;

    private void Start()
    {
        spawnPlatform = parentObject.GetComponentsInChildren<Transform>();
        //if (isStarterFactory == true) InvokeRepeating("GenerateResources", 1.5f, generationInterval);
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= generationInterval)
        {
            GenerateResources(0); 
            timer = 0f; 
        }
    }
    public void GenerateResources(int amount)
    {
        if(isStarterFactory == true)
        {
            if (currentResourcesOnPlatform >= maxResourcesOnPlatform) return;
        }
        else
        {
            if (currentResourcesOnPlatform >= amount)
            {
                return;
            }
        }
      
        int randomindex = Random.Range(0, spawnPlatform.Length);

        Instantiate(resourcePrefab, spawnPlatform[randomindex].position, Quaternion.identity);
        currentResourcesOnPlatform++;
    }
}
