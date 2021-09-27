using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform rootTransform;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the collider: " + other.name);
        other.transform.parent = rootTransform; // Replacing parent!!
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}