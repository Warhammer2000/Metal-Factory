using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Copper, Iron, Dural
}

public class Resource : MonoBehaviour
{
    [SerializeField] ResourceData data;

    public ResourceData Data => data;

}

[Serializable]
public struct ResourceData
{
    public ResourceType Type;
}
