using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Industry
{
    public class PlayerMovement : MonoBehaviour
    {
        private MovementSettings _settings;

        private CharacterController _characterController;

        [Inject]
        private void Construct(MovementSettings settings)
        {
            _settings = settings;
            Debug.Log($"Instalation of {settings} are successed");
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? _settings.accelerationSpeed : _settings.moveSpeed;

            Vector3 movementInput = new Vector3(horizontalInput, 0f, verticalInput);

            Vector3 velocityVector = movementInput * moveSpeed * Time.deltaTime;
            _characterController.Move(velocityVector);
        }
    }
}
