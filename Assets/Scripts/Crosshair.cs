using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image Cross;
    public Image Reticle;

    public Transform Gun;
    public Transform Cam;
    public Transform GunCam;

    float BulletsLeft;

    //private BulletPool pool;

    void Start()
    {
        //pool = FindObjectOfType<BulletPool>();

        Reticle.color = new Color(255, 255, 255, 255);
        Cross.color = new Color(0, 0, 255, 200);
        //BulletsLeft = pool.AmountToPool;
    }

    void Update()
    {
        Shoot();
        if(Input.GetKey(KeyCode.Mouse1))
        {
            scope();
        }
        //RayCasting();
        
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }*/

        //Cross.fillAmount = (float)(BulletsLeft / pool.AmountToPool);
    }

    void Shoot()
    {
        if (Physics.Raycast(Cam.position, Cam.forward * 10f, out RaycastHit hitInfo))
        {
            //Vector3 direction = hitInfo.point - Gun.position;
            //Gun.rotation = Quaternion.LookRotation(direction);

            var Target = hitInfo.transform;

            if (Target.CompareTag("Target"))
            {
                if(Input.GetKey(KeyCode.Mouse0))
                {
                    //Target.gameObject.SetActive(false);
                    Destroy(Target.gameObject, 0.1f);
                }
                Reticle.color = new Color(255, 0, 0, 255);
                Cross.color = new Color(0, 255, 0, 200);
            }
            else
            {
                Reticle.color = new Color(255, 255, 255, 255);
                Cross.color = new Color(0, 0, 255, 200);
            }
        }
        Debug.DrawRay(Cam.position, Cam.forward * 10f, Color.red);
        Debug.DrawRay(GunCam.position, GunCam.forward * 10f, Color.green);
    }

    void scope()
    {
        if (Physics.Raycast(GunCam.position, GunCam.forward * 10f, out RaycastHit hitInfo))
        {
            var Target = hitInfo.transform;
            if (Target.CompareTag("Target"))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    //Target.gameObject.SetActive(false);
                    Destroy(Target.gameObject, 0.1f);
                }
                Reticle.color = new Color(255, 0, 0, 255);
                Cross.enabled = false;
                //Cross.color = new Color(0, 255, 0, 200);
            }
        }
    }

    /*void Shoot()
    {
        GameObject Bullet = BulletPool.SharedInstance.GetPooledObjects();
        if (Bullet != null)
        {
            BulletsLeft--;
        }

        Debug.Log("F = " + Cross.fillAmount);
        Debug.Log("B = " + BulletsLeft);
    }*/

    /*void Reload()
    {
        //BulletsLeft = pool.AmountToPool;

        /*Debug.Log("F = " + Cross.fillAmount);
        Debug.Log("B = " + BulletsLeft);
    }*/

        /*void RayCasting()
        {
            Ray ray = new Ray(ShootPoint.position, ShootPoint.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var Target = hit.transform;
                if (Target.CompareTag("Zombie"))
                {
                    Reticle.color = new Color(255, 0, 0, 255);
                    Cross.color = new Color(255, 0, 0, 200);
                }
                else if (Target.CompareTag("Target"))
                {
                    Reticle.color = new Color(0, 255, 0, 255);
                    Cross.color = new Color(0, 255, 0, 200);
                }
                else
                {
                    Reticle.color = new Color(255, 255, 255, 255);
                    Cross.color = new Color(0, 0, 255, 200);
                }
            }
            Debug.DrawRay(ShootPoint.position, ShootPoint.forward * 10f, Color.red);
        }*/
    }