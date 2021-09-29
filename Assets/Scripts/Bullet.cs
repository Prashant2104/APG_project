using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 10f;

    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * BulletSpeed * 10 * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.SetActive(false);
    }
}