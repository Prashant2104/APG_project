using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject ReloadText;

    private void Start()
    {
        ReloadText.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void Shoot()
    {
        GameObject Bullet = BulletPool.SharedInstance.GetPooledObjects();
        if (Bullet != null)
        {
            Bullet.transform.position = transform.position;
            Bullet.transform.rotation = transform.rotation;
            Bullet.SetActive(true);
            ReloadText.SetActive(false);
        }

        if (Bullet == null)
        {
            ReloadText.SetActive(true);
        }
    }

    public void Reload()
    {
        ReloadText.SetActive(false);
    }
}