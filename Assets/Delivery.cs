using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool isDelivering = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandlePackageDelivery(collision);

        Debug.Log("Collision detected with " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePackagePickup(collision);
    }

    private void HandlePackageDelivery(Collision2D collision)
    {
        if (isDelivering && collision.gameObject.CompareTag("Customer"))
        {
            isDelivering = false;
            Debug.Log("Package delivered!");
        }
    }

    private void HandlePackagePickup(Collider2D collision)
    {
        if (collision.CompareTag("Package"))
        {
            Debug.Log("Package picked up!");
            Destroy(collision.gameObject);
            isDelivering = true;
        }
    }
}
