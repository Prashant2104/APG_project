using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Image Cross;
    public Image Reticle;

    public GameObject Cam;
    public GameObject GunCam;

    public float Range;
    public float ScopeRange;
    public float Bullets;
    public float DamageAmount;
    float BulletsLeft;

    public GameObject ReloadText;
    public GameObject FlashLight;
    public bool IsLightOn;

    public bool ScopeIn;

    private GameManager GM;
    public GunMuzzleFlash muzzleFlash;
    private AudioManager audioManager;
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        ScopeIn = false;
        IsLightOn = false;
        Reticle.color = new Color(255, 255, 255, 255);
        Cross.color = new Color(0, 0, 255, 200);
        BulletsLeft = Bullets;
        ReloadText.SetActive(false);
    }

    void Update()
    {
        if (IsLightOn && GM.GunCollected)
        {
            FlashLight.SetActive(true);
        }
        else
        {
            FlashLight.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            IsLightOn = !IsLightOn;
            audioManager.Interacted();
        }

        if (GM.Puzzle2 == true)
        {           
            if (Input.GetKeyDown(KeyCode.Mouse0) && BulletsLeft > 0)
            {
                audioManager.Shooting();
                BulletsLeft--;
                muzzleFlash.StartFiring();

                if (ScopeIn == false)
                {
                    Shoot();
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                muzzleFlash.StopFiring();
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                ScopeIn = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                ScopeIn = false;
            }

            if (ScopeIn == true)
            {
                Scope();
                GunCam.GetComponent<Camera>().targetDisplay = 0;
                Cam.GetComponent<Camera>().targetDisplay = 1;
                Cross.enabled = false;
                Reticle.enabled = false;
            }
            if (ScopeIn == false)
            {
                GunCam.GetComponent<Camera>().targetDisplay = 1;
                Cam.GetComponent<Camera>().targetDisplay = 0;
                Cross.enabled = true;
                Reticle.enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }

        RayCasting();

        Cross.fillAmount = (float)(BulletsLeft / Bullets);
        if(BulletsLeft == 0)
        {
            ReloadText.SetActive(true);
        }
    }

    void Shoot()
    {
        Cross.enabled = true;
        Reticle.enabled = true;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out RaycastHit hit, Range))
        {
            //Debug.Log("gun = " + hit.transform.gameObject.transform.name);
            TargetController target = hit.transform.GetComponent<TargetController>();
            if (target != null)
            {
                target.TakeDamage(DamageAmount);
                if(target.gameObject.CompareTag("Bulb"))
                {
                    audioManager.BulbShatter();
                }
            }
        }
    }
    void Scope()
    {
        if (Physics.Raycast(GunCam.transform.position, GunCam.transform.forward, out RaycastHit hitInfo, ScopeRange))
        {
            //Debug.Log("scope = "+hitInfo.transform.gameObject.transform.name);
            TargetController target = hitInfo.transform.GetComponent<TargetController>();
          
            if (Input.GetKeyDown(KeyCode.Mouse0) && BulletsLeft > 0)
            {
                if (target != null)
                {
                    target.TakeDamage(DamageAmount); 
                    if (target.gameObject.CompareTag("Bulb"))
                    {
                        audioManager.BulbShatter();
                    }
                }
            }
        }
    }   
    IEnumerator Reload()
    {
        audioManager.Reloading();
        yield return new WaitForSeconds(0.65f);
        BulletsLeft = Bullets;
        ReloadText.SetActive(false);
    }
    void RayCasting()
    {
        //Debug.DrawRay(Cam.transform.position, Cam.transform.forward * Range, Color.red);
        //Debug.DrawRay(GunCam.transform.position, GunCam.transform.forward * ScopeRange, Color.green);
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out RaycastHit hit, Range) && ScopeIn == false)
        {
            TargetController target = hit.transform.GetComponent<TargetController>();
            if (target != null)
            {
                Reticle.color = new Color(255, 0, 0, 255);
                //Cross.color = new Color(0, 255, 0, 200);
            }
            else
            {
                Reticle.color = new Color(255, 255, 255, 255);
                //Cross.color = new Color(0, 0, 255, 200);
            }                       
        }
    }

    /*void RotateGun()
    {
        //Vector3 direction = hitInfo.point - Gun.position;
        //Gun.rotation = Quaternion.LookRotation(direction);
    }*/
}