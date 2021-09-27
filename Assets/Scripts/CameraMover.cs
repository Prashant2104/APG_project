using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] Transform cameraPosition = null;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}