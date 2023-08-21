using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;
using Zenject.SpaceFighter;

[RequireComponent(typeof(Inventory))]
public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private Text NeedIron;
    [SerializeField] private Text NeedCoprum;
    [SerializeField] private Text NeedDural;
    
  
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        IntializeText();
    }
    private void IntializeText()
    {
       NeedIron.text = "Железа : ";
       NeedCoprum.text = "Меди : ";
       NeedDural.text = "Алюминия : ";
    }

    private void Update()
    {
        GetIron();
    }
  
    private void GetIron()
    {
        int ironCount = 0;
        int CopperCount = 0;
        int DuralCount = 0;
        for (int i = 0; i < inventory.resources.Count; i++)
        {
            if (inventory.resources[i].Type == ResourceType.Iron)
            {
                ironCount += inventory.resources[i].Amount;
            }
            if (inventory.resources[i].Type == ResourceType.Copper)
            {
                CopperCount += inventory.resources[i].Amount;
            }
        }
        for(int i = 0; i < inventory.resourceDural.Count; i++)
        {
            if (inventory.resourceDural[i].Type == ResourceType.Dural)
            {
                DuralCount += inventory.resourceDural[i].Amount;
            }
        }
        NeedIron.text = $"Железа : {ironCount} / {ironCount}";
        NeedCoprum.text = $"Меди :{CopperCount} / {CopperCount}";
        NeedDural.text = $"Алюминия :{DuralCount} / {DuralCount}";

    }
}
//private void Dataoutput()
//{
//    Dictionary<ResourceType, int> resourceCounts = new Dictionary<ResourceType, int>();

//    for (int i = 0; i < inventory.resources.Count; i++)
//    {
//        ResourceType type = inventory.resources[i].Type;
//        if (!resourceCounts.ContainsKey(type))
//        {
//            resourceCounts[type] = 0;
//        }
//        resourceCounts[type]++;
//    }
//    foreach (var kvp in resourceCounts)
//    {
//        if (kvp.Key == ResourceType.Iron)
//        {

//        }
//        if (kvp.Key == ResourceType.Copper)
//        {


//        }
//        if (kvp.Key == ResourceType.Dural)
//        {


//        }
//    }
//}