using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0f;
    [SerializeField] float deltaSteer = 0.5f;
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float deltaMove = 0.1f;
    [SerializeField] float deceleration = 0.95f;

    void Start()
    {
    }

    void Update()
    {
        HandleSteering();
        HandleMovementSpeed();
        GraduallyReduceSpeed();
    }

    private void GraduallyReduceSpeed()
    {
        moveSpeed *= deceleration;
        steerSpeed *= deceleration;
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
        steerSpeed -= horizontalInput * deltaSteer * Time.deltaTime;
        transform.Rotate(0, 0, steerSpeed);
    }
}
