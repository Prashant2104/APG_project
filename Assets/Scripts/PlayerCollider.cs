using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Platform"))
        {
            gameObject.GetComponentInParent<Transform>().transform.parent = other.transform;
            //gameObject.transform.parent = other.transform;
        }*/
        if (other.CompareTag("Water"))
        {
            gameObject.transform.position = new Vector3(10, 10, 10);
        }
    }
}
