using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : Interactable
{
    private GameManager GM;
    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }
    public override void Interact(GameObject Actor)
    {
        base.Interact(Actor);
        ChangeColor();
    }

    void ChangeColor()
    {
        GM.BoxCollected++;
        //gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 255);
        gameObject.SetActive(false);
    }
}