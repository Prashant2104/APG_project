using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair_Target : MonoBehaviour
{
    public GameObject Cam;
    public float Range;
    void Update()
    {
            Physics.Raycast(Cam.transform.position, Cam.transform.forward, out RaycastHit hit, Range);
            transform.position = hit.point;
    }
}
