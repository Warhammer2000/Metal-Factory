using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Inventory))]
public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Text NeedIron;
    [SerializeField] private Text NeedCoprum;
    private int ironCount = 0;
    private int copperCount = 0;
    public bool isCuprumFactory;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();  
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Information();
    }
    public void Information()
    {
        Dictionary<ResourceType, int> resourceCounts = new Dictionary<ResourceType, int>();

        for (int i = 0; i < inventory.resources.Count; i++)
        {
            ResourceType type = inventory.resources[i].Type;
            if (!resourceCounts.ContainsKey(type))
            {
                resourceCounts[type] = 0;
            }
            resourceCounts[type]++;
        }

        // ќбновл€ем текстовые пол€ на основе сохраненных значений в словаре
        foreach (var kvp in resourceCounts)
        {
            if (kvp.Key == ResourceType.Iron)
            {
                NeedIron.text = $"{kvp.Value} / {kvp.Value}";
            }
            if (kvp.Key == ResourceType.Copper)
            {
                NeedCoprum.text = $"{kvp.Value} / {kvp.Value}"; 
            }
            // ƒобавьте услови€ дл€ других типов ресурсов по аналогии
        }
       
    }
}
//for(int i = 0; i < inventory.resources.Count; i++)
//{
//    if(inventory.resources[i].Type == ResourceType.Iron)
//    {
//        ironCount++;
//    }
//    if (inventory.resources[i].Type == ResourceType.Copper)
//    {
//        copperCount++;
//    }
//}
//NeedIron.text = ironCount.ToString();
//if (!isCuprumFactory)
//{
//    NeedCoprum.text = copperCount.ToString();
//}