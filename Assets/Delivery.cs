using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool isDelivering = false;
    [SerializeField] private float destroyDelay = 0.5f;
    [SerializeField] private Color32 hasPackageColor = new Color32(255, 128, 128, 255);
    [SerializeField] private Color32 noPackageColor = new Color32(255, 255, 255, 255);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

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
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package delivered!");
        }
    }

    private void HandlePackagePickup(Collider2D collision)
    {
        if (!isDelivering && collision.CompareTag("Package"))
        {
            Debug.Log("Package picked up!");
            Destroy(collision.gameObject, destroyDelay);
            isDelivering = true;
            spriteRenderer.color = hasPackageColor;
        }
    }
}
