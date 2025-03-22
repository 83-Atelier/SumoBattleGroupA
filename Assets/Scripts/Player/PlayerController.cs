using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = InputManager.Instance.MoveAction.ReadValue<Vector2>();
        body.AddForce(new Vector3(movement.x, 0, movement.y));
    }
}
