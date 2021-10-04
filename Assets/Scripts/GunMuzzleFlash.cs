using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMuzzleFlash : MonoBehaviour
{
    public bool isFiring = false;
    public ParticleSystem[] muzzleFlash;
    //public ParticleSystem hitEffect;
    //public Transform raycastOrigin;
    //public Transform raycastDestination;
    //public float range = 10f;

    public void StartFiring()
    {
        isFiring = true; foreach (var partical in muzzleFlash)
        {
            partical.Emit(1);
        }
        //FireBullet();
    }
    public void StopFiring()
    {
        isFiring = false;
    }
    /*private void FireBullet()
    {
       
        Physics.Raycast(raycastOrigin.position, raycastDestination.position - raycastOrigin.position, out RaycastHit hitInfo, range);
        if (Physics.Raycast(raycastOrigin.position, raycastDestination.position - raycastOrigin.position, out hitInfo, range))
        {
            hitEffect.transform.position = hitInfo.point;
            hitInfo.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);
        }
    }*/
}