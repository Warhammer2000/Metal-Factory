using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Industry
{
    public class PlayerMovement : MonoBehaviour
    {
        private MovementSettings _settings;
        private Rigidbody _rb;

       

        [Inject]
        private void Construct(MovementSettings settings)
        {
            _settings = settings;
            Debug.Log($"Instalation of {settings} are successed");
        }
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");


            float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? _settings.accelerationSpeed : _settings.moveSpeed;

            Vector3 desiredVelocity = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
            Vector3 accelerationVector = (desiredVelocity - _rb.velocity) * _settings.accelerationSpeed * Time.deltaTime;
            Vector3 movement = accelerationVector * Time.deltaTime;

            Move(movement);
        }

        private void Move(Vector3 movement)
        {
            _rb.MovePosition(transform.position + movement);
        }
    }

}
