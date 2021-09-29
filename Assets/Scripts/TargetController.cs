using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Vector3 InitialPos, CurrentPos;
    // Start is called before the first frame update
    void Start()
    {
        InitialPos = gameObject.transform.position;
        CurrentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(CurrentPos.x <= InitialPos.x + 10f)
        {
            transform.Translate(+0.1f, 0, 0);
            CurrentPos.x += 0.1f;
        }
        else if (CurrentPos.x >= InitialPos.x - 10f)
        {
            transform.Translate(-0.1f, 0, 0);
            CurrentPos.x -= 0.1f;
        }
    }
}
