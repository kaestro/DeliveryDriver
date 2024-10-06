using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Driver"))
        {
            Driver driver = collision.gameObject.GetComponent<Driver>();

            if (driver != null)
            {
                driver.hitBump();
            }
        }
    }
}
