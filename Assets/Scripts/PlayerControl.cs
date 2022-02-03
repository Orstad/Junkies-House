using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _groundCheck;

    private float _speed = 10f;
    private float _movementX;
    private float _movementZ;
    private float _jumpPower = 10f;

    private float _gravityCoefficient = -9.8f;
    private Vector3 _gravityVelocity;

    private float _groundDistance = 0.5f;
    private bool _isGrounded;

    private void Update()
    {
        MoveBody();
        Gravity();
    }
    
    private void MoveBody()
    {
        _movementX = Input.GetAxis("Horizontal");
        _movementZ = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * _movementX + transform.forward * _movementZ;
        _controller.Move(direction * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _gravityVelocity.y = Mathf.Sqrt(_jumpPower * -2f * _gravityCoefficient);
            Debug.Log("zhopa popa");
        }
    }

    private void Gravity()
    {
        _isGrounded = Physics.Raycast(_groundCheck.position, Vector3.down, _groundDistance);

        if (_isGrounded && _gravityVelocity.y < 0)
        {
            _gravityVelocity.y = -2f;
        }

        _gravityVelocity.y += _gravityCoefficient * 4 * Time.deltaTime;
        _controller.Move(_gravityVelocity * Time.deltaTime);
    }

}
