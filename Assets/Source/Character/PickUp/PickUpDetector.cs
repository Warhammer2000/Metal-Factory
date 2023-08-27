using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PickUpDetector : MonoBehaviour
{
  
    public Action<ResourceData> OnPickUp;
    [Inject]
    [SerializeField] private ObjectPool pool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Resource>(out var resource))
        {
            OnPickUp?.Invoke(resource.Data);

            if (resource.isIron)
            {
                GameObject pooledObject = pool.GetObjectFromPool(); // Получаем объект из пула


                pooledObject.SetActive(false);
                // Вместо уничтожения объекта, деактивируйте его, чтобы вернуть в пул
                resource.gameObject.SetActive(false);

            }
            else
            {
                Destroy(resource.gameObject);   
            }
            
        }
    }
}
