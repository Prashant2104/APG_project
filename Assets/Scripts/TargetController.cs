using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    //public Vector3 InitialPos, CurrentPos;
    //public float speed;

    public float health;
    private GameManager GM;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        //InitialPos = gameObject.transform.position;
        //CurrentPos = gameObject.transform.position;
    }

    /*void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);
        CurrentPos.x += speed;

        if(CurrentPos.x >= InitialPos.x + 10f)
        {
            speed = -speed;
        }
        else if (CurrentPos.x <= InitialPos.x - 10f)
        {
            speed = -speed;
        }
    }*/

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(gameObject.CompareTag("Zombie"))
            {
                GM.ZombiesKilled++;
            }
            if(gameObject.CompareTag("Civilian"))
            {
                GM.GameOverPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            gameObject.SetActive(false);
        }
    }
}