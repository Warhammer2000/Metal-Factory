using UnityEngine;

public class ResourceFactory : MonoBehaviour
{
    [SerializeField] private GameObject resourcePrefab;
    [SerializeField] private Transform parentObject;
    [SerializeField] private Transform[] spawnPlatform; 
    public float generationInterval = 0.5f; 
    private int maxResourcesOnPlatform = 10000;

    private float timer = 0f;



    public int currentResourcesOnPlatform = 0;

    public bool isStarterFactory;

    private void Start()
    {
        spawnPlatform = parentObject.GetComponentsInChildren<Transform>();
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
