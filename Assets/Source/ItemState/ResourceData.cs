using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Resources", menuName = "Resource")]
public class ResourceData : ScriptableObject
{
    public ResourceType Type;
    public int Amount = 1;
}
