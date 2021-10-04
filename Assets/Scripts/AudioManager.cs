using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject Bulb;
    public GameObject Shoot;
    public GameObject Reload;
    public GameObject Interact;
    public void BulbShatter()
    {
        Bulb.GetComponent<AudioSource>().Play();
    }
    public void Shooting()
    {
        Shoot.GetComponent<AudioSource>().Play();
    }
    public void Reloading()
    {
        Reload.GetComponent<AudioSource>().Play();
    }
    public void Interacted()
    {
        Interact.GetComponent<AudioSource>().Play();
    }
}