using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Trigger water");
            FindObjectOfType<PlayerController>().Respawner();
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.CompareTag("Wood") && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Wood");
        }
    }
}