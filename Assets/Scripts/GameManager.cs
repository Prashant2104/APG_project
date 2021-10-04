using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float BulletCollected;
    public bool GunCollected;
    public float ZombiesKilled;

    public GameObject Bullets;
    public int BulletCount;

    public int ZombieCount;
    public GameObject Zombies;
    public GameObject Civilians;

    public GameObject Book;
    public GameObject BookPanel;

    public Text ScoreText;
    public GameObject ScorePanel;

    public GameObject PlayerGun;
    public GameObject Flashlight;
    public GameObject CollectableGun;

    public bool IsFlashOn;
    public bool Puzzle1, Puzzle2, Puzzle3;

    void Start()
    {
        Flashlight.SetActive(true);
        PlayerGun.SetActive(false);
        Bullets.SetActive(false);
        CollectableGun.SetActive(false);

        Zombies.SetActive(false);
        Civilians.SetActive(false);

        Book.SetActive(true);
        BookPanel.SetActive(false);

        IsFlashOn = true;
        Puzzle1 = false;
        Puzzle2 = false;
        Puzzle3 = false;
        BulletCollected = 0;
        ScorePanel.SetActive(true);
    }

    void Update()
    {
        ScoreText.text = "Collected = " + BulletCollected;
                
        if(Input.GetKeyDown(KeyCode.F) && GunCollected == false)
        {
            IsFlashOn = !IsFlashOn;
            Flashlight.transform.GetChild(0).gameObject.SetActive(IsFlashOn);
        }

        if(BookPanel.activeInHierarchy == true)
        {
            Puzzle1 = true;
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                BookPanel.SetActive(false);
            }
            Book.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            Book.SetActive(true);
            Time.timeScale = 1f;
        }

        if(BulletCollected >= BulletCount)
        {
            Puzzle2 = true;
        }
        if(ZombiesKilled >= ZombieCount)
        {
            Puzzle3 = true;
        }

        if(Puzzle1)
        {
            CollectableGun.SetActive(true);
            if (GunCollected)
            {
                CollectableGun.SetActive(false);
                Flashlight.SetActive(false);
                PlayerGun.SetActive(true);
                Bullets.SetActive(true);
            }
        }
        if(Puzzle2)
        {
            Zombies.SetActive(true);
            Civilians.SetActive(true);
        }
    }
}