using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 0f;
    [SerializeField] private float deltaSteer = 0.5f;
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float deltaMove = 0.1f;
    [SerializeField] private float deceleration = 0.99f;
    [SerializeField] private float boostSpeed = 0.2f;
    [SerializeField] private float bumpDegradation = 0.5f;

    private void Update()
    {
        HandleSteering();
        HandleMovementSpeed();
        GraduallyReduceSpeed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            moveSpeed += boostSpeed;
        }
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

    public void hitBump()
    {
        moveSpeed *= bumpDegradation;
    }
}
