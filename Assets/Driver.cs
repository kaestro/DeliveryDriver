using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.01f;
    [SerializeField] float deltaSteer = 0.0001f;
    [SerializeField] float moveSpeed = 0.001f;
    [SerializeField] float deltaMove = 0.0001f;

    void Start()
    {
    }

    void Update()
    {
        HandleSteering();
        HandleMovementSpeed();
    }

    private void HandleMovementSpeed()
    {
        float verticalInput = Input.GetAxis("Vertical");
        moveSpeed += verticalInput * deltaMove * Time.deltaTime;
        transform.Translate(0, moveSpeed, 0);
    }

    private void HandleSteering()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        steerSpeed += horizontalInput * deltaSteer * Time.deltaTime;
        transform.Rotate(0, 0, steerSpeed);
    }
}
