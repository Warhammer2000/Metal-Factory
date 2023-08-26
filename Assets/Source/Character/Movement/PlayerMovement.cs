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
            Debug.Log($"Installation of {settings} is successful");
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

            Vector3 rotatedMovement = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * movementInput;

            Vector3 velocityVector = rotatedMovement * moveSpeed * Time.deltaTime;
            _characterController.Move(velocityVector);

            // ��������� �������� �� �����������
            float rotationInput = 0f;
            if (Input.GetKey(KeyCode.E))
            {
                rotationInput = 1f; // ������������ ������ ��� ������� E
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                rotationInput = -1f; // ������������ ����� ��� ������� Q
            }

            transform.Rotate(Vector3.up * rotationInput * _settings.rotationSpeed * Time.deltaTime);
        }
    }
}
