using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{

    public GameObject prefab;      
    public int poolSize = 5;        
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private List<GameObject> poolObject = new List<GameObject>();
    [SerializeField] private Transform parentTransform;
    private void Awake()
    {
        spawnPoints = transform.GetComponentsInChildren<Transform>();
    }
    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Spawn platform array is empty!");
            return;
        }
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            GameObject obj = Instantiate(prefab, spawnPoints[randomIndex].position, Quaternion.identity, spawnPoints[1]);
            obj.SetActive(true);
            poolObject.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in poolObject)
        {
            if (obj.activeInHierarchy)
            {
                obj.SetActive(false);
                StartCoroutine(DeactivateAndReactivatePool(obj));
                return obj;
            }
        }
        Debug.LogWarning("Pull пустой");
        return null; 
    }

    private IEnumerator DeactivateAndReactivatePool(GameObject obj)
    { 
       
        yield return new WaitForSeconds(6.0f);

        for(int i = 0; i < parentTransform.childCount; i++)
        {
            Transform child = parentTransform.GetChild(i);
            child.gameObject.SetActive(true);
        }
        Debug.Log("Child are active");
        yield return new WaitForSeconds(1.0f); 
    }

}
