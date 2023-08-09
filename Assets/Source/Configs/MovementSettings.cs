using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Industry
{
    [CreateAssetMenu(fileName = "MovementSettings", menuName = "Movement settings")]
    public class MovementSettings : ScriptableObject
    {
        [field: SerializeField] public float moveSpeed { get; private set; }
        [field: SerializeField] public float accelerationSpeed { get; private set; }
        private void OnValidate()
        {
            if (moveSpeed < 0) moveSpeed = 0;
            if (accelerationSpeed < 0) moveSpeed = 0;
        }
    }
}
