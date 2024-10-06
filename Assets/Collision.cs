using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detected with " + collision.gameObject.name);
    }
}
