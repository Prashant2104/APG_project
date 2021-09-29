using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Vector3 InitialPos, CurrentPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InitialPos = gameObject.transform.position;
        CurrentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);
        CurrentPos.x += speed;

        if(CurrentPos.x >= InitialPos.x + 10f)
        {
            speed = -speed;
        }
        else if (CurrentPos.x <= InitialPos.x - 10f)
        {
            speed = -speed;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }*/
}