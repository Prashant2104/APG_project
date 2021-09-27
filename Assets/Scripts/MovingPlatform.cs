using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform start; // A
    public Transform end;   // B
    public float t;         // Interpolant
    public float speed = 1;     // in m/s
    public float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        speedMultiplier = speed / Vector3.Distance(start.position, end.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speedMultiplier = speed / Vector3.Distance(start.position, end.position);
        t = t + Time.deltaTime; // Use speedMultiplier here instead!

        // Cosine range: -1 to +1 // 2
        // Needed range: 0 to 1   // 1
        // A:
        // Original = -1,1
        // Divide 2 = -0.5, 0.5
        // Add 0.5 = 0, 1
        // B:
        // Original = -1, 1
        // Add 1    = 0, 2
        // Divide 2 = 0, 1
        // Find cosine, change the range from (-1,1) to (0,1)

        float cosT = (Mathf.Cos(t * Mathf.PI * speedMultiplier) + 1) / 2;

        // Vector3.Lerp(start.position, end.position, t);

        transform.position = start.position * (1 - cosT) + end.position * cosT;

        /*if(transform.position == end.position)
        {
            this.enabled = false;
        }*/
    }
}
