using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AndroidVersionControll : MonoBehaviour
{
    [SerializeField] private GameObject ButtonEscape;
    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.LogWarning(Application.platform);
            Debug.LogWarning("Android");
        }
        else
        {
            Debug.LogWarning(Application.platform);
            Debug.LogWarning("Editor");
            gameObject.SetActive(false); // Деактивация объекта только в редакторе
            ButtonEscape.SetActive(false);
        }
    }
}

