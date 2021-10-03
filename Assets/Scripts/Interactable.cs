using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool IsActive { get; set; }

    public virtual void Interact(GameObject Actor)
    {

    }

    private void Start()
    {
        IsActive = true;
    }
}