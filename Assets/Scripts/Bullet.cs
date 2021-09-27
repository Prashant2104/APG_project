using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 10f;

    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.R))
        {
            gameObject.SetActive(false);
        }
    }    
}