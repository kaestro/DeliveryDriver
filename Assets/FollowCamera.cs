using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject thingToFollow;

    // Camera's position should be the same as the car's position
    void LateUpdate()
    {
        transform.position = new Vector3(thingToFollow.transform.position.x, thingToFollow.transform.position.y, thingToFollow.transform.position.z - 10);
    }
}
