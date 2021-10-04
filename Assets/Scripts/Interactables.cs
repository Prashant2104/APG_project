using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : Interactable
{
    private GameManager GM;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        GM = FindObjectOfType<GameManager>();
    }
    public override void Interact(GameObject Actor)
    {
        base.Interact(Actor);
        interacted();
    }

    void interacted()
    {
        audioManager.Interacted();
        if (gameObject.CompareTag("Gun"))
        {
            GM.GunCollected = true;
        }
        else if(gameObject.CompareTag("Book"))
        {
            GM.BookPanel.SetActive(true);
        }
        else
        {
            GM.BulletCollected++;
        }
        //gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 255);
        gameObject.SetActive(false);
    }
}