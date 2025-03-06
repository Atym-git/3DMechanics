using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;

    [SerializeField] private float _jumpForce = 5;

    private Rigidbody _rb;

    private InputAction _movement;

    private InputAction _jump;

    private PlayerMovementSystem _playerMovementSystem;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMovementSystem = new PlayerMovementSystem();
        Bind();
    }

    private void Bind()
    {
        _movement = _playerMovementSystem.Game.Movement;
        _movement.Enable();
        _playerMovementSystem.Game.Jump.performed += Jump;
        _playerMovementSystem.Game.Jump.Enable();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        _rb.velocity = Vector3.up * _jumpForce;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 _movement2d = _movement.ReadValue<Vector2>().normalized;
        _rb.velocity = new Vector3(_movement2d.x, 0, _movement2d.y) * _moveSpeed;
    }
}
