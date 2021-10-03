using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger water");
            FindObjectOfType<PlayerController>().Respawner();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision water");
            FindObjectOfType<PlayerController>().Respawner();
        }
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Controller water");
            FindObjectOfType<PlayerController>().Respawner();
        }
    }
}