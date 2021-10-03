using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableReticle : MonoBehaviour
{
    public Image Reticle;
    public Transform Cam;

    public float Range;

    private Interactable currentObject;
    private float startTime;
    void Update()
    {
        Ray ray = new Ray(Cam.position, Cam.forward);
        Debug.DrawRay(Cam.transform.position, Cam.transform.forward * Range, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hit, Range))
        {
            Interactable i = hit.collider.GetComponent<Interactable>();

            if(i != currentObject)
            {
                startTime = Time.time;
                currentObject = i;
            }
            if(currentObject != null)
            {
                if(Time.time - startTime > 1)
                {
                    currentObject.Interact(Cam.gameObject);
                    startTime = 0;
                    currentObject = null;
                }
                Reticle.enabled = true;
                Reticle.fillAmount = Time.time - startTime;
            }
            else
            {
                Reticle.fillAmount = 0;
                Reticle.enabled = false;
            }
        }
        else
        {
            Reticle.fillAmount = 0;
            Reticle.enabled = false;
        }
    }
}