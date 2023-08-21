using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "Resource")]
public class ResourceData : ScriptableObject
{
    public ResourceType Type;
    [field: SerializeField] public int Amount { get; set; }
}
