using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FactoryInventory))]
public class FactoryInventoryUI : MonoBehaviour
{
    private FactoryInventory inventory;
   
    [SerializeField] private Text NeedIron;
    [SerializeField] private Text NeedCoprum;

    public bool isCuprumFactory;
    private void Awake()
    {
        inventory = GetComponent<FactoryInventory>();
        IntializeText();
    }
    private void IntializeText()
    {
        if (isCuprumFactory) NeedIron.text = "Железа : ";
        else
        {
            NeedIron.text = "Железа : ";
            NeedCoprum.text = "Меди : ";
        }
    }
    private void FixedUpdate()
    {
        Dataoutput();
    }
    private  void Dataoutput()
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
        foreach (var kvp in resourceCounts)
        {
            if (kvp.Key == ResourceType.Iron)
            {
                NeedIron.text = $"Железа : {kvp.Value} / {kvp.Value}";
            }
            if (kvp.Key == ResourceType.Copper)
            {
                if (!isCuprumFactory) NeedCoprum.text = $"Меди :{kvp.Value} / {kvp.Value}";
                else Debug.Log("ФАбрика меди");
            }
        }
    }
}
