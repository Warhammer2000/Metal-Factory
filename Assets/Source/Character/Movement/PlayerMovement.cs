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
        [SerializeField] private Joystick joystick;


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
            PCMovement();
            //if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            //{
            //    Android_IOSMovement();
            //}
            //else
            //{
            //    PCMovement();
            //}
        }
        private void Android_IOSMovement()
        {
            float horizontalInput = joystick.Horizontal;
            float verticalInput = joystick.Vertical;

            float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? _settings.accelerationSpeed : _settings.moveSpeed;

            Vector3 movementInput = new Vector3(horizontalInput, 0f, verticalInput);

            Vector3 rotatedMovement = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * movementInput;

            Vector3 velocityVector = rotatedMovement * moveSpeed * Time.deltaTime;
            _characterController.Move(velocityVector);

            // Добавляем повороты по горизонтали
            float rotationInput = 0f;
            if (Input.GetKey(KeyCode.E))
            {
                rotationInput = 1f; // Поворачиваем вправо при нажатии E
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                rotationInput = -1f; // Поворачиваем влево при нажатии Q
            }

            // Получение входных данных от джойстика по горизонтали
            float horizontalJoystickInput = joystick.Horizontal;

            rotationInput += horizontalJoystickInput;

            transform.Rotate(Vector3.up * rotationInput * _settings.rotationSpeed * Time.deltaTime);
        }
        private void PCMovement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? _settings.accelerationSpeed : _settings.moveSpeed;

            Vector3 movementInput = new Vector3(horizontalInput, 0f, verticalInput);

            Vector3 rotatedMovement = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * movementInput;

            Vector3 velocityVector = rotatedMovement * moveSpeed * Time.deltaTime;
            _characterController.Move(velocityVector);

            // Добавляем повороты по горизонтали
            float rotationInput = 0f;
            if (Input.GetKey(KeyCode.E))
            {
                rotationInput = 1f; // Поворачиваем вправо при нажатии E
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                rotationInput = -1f; // Поворачиваем влево при нажатии Q
            }
            transform.Rotate(Vector3.up * rotationInput * _settings.rotationSpeed * Time.deltaTime);
        }
    }
}
