using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Text Tasks;

    public Text ScoreText;
    public GameObject ScorePanel;

    public Text GameOverText;
    public GameObject GameOverPanel;

    public GameObject PausePanel;
    public CharacterController Player;

    public GameObject PlayerGun;
    public GameObject Flashlight;
    public GameObject CollectableGun;
    public GameObject AudioCam;
    public GameObject InstructionsPanel;

    public Animator[] CivilianAnimation;

    public bool instruction;
    public bool IsFlashOn;
    public bool IsSoundOn;
    public bool IsPaused;
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

        instruction = false;
        IsPaused = false;
        IsSoundOn = true;
        IsFlashOn = true;
        Puzzle1 = false;
        Puzzle2 = false;
        Puzzle3 = false;
        BulletCollected = 0;
        ScorePanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);

        GameOverText.text = "You Failed";
        Tasks.text = "Task: Find a SafeHouse And a way into it";
    }

    void Update()
    {
        ScoreText.text = "Ammo Collected = " + BulletCollected + " / " + BulletCount;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InstructionsPanel.SetActive(false);
            IsPaused = !IsPaused;
            PausePanel.SetActive(IsPaused);
        }
        if (IsPaused)
        {
            Player.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Player.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; ;
        }


        if (Input.GetKeyDown(KeyCode.F) && GunCollected == false)
        {
            IsFlashOn = !IsFlashOn;
            Flashlight.transform.GetChild(0).gameObject.SetActive(IsFlashOn);
        }

        if (BookPanel.activeInHierarchy == true)
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

        if (BulletCollected >= BulletCount)
        {
            Puzzle2 = true;
        }
        if (ZombiesKilled >= ZombieCount)
        {
            Puzzle3 = true;
        }

        if (Puzzle1)
        {
            Tasks.text = "Task: Find the Gun";
            CollectableGun.SetActive(true);
            if (GunCollected)
            {
                Tasks.text = "Task: Find all the Ammo";
                ScorePanel.SetActive(true);
                CollectableGun.SetActive(false);
                Flashlight.SetActive(false);
                PlayerGun.SetActive(true);
                Bullets.SetActive(true);
            }
        }
        if (Puzzle2)
        {
            Tasks.text = "Task: Find the Zombies, and kill them without hurting the Civilians";
            ScorePanel.SetActive(false);
            Zombies.SetActive(true);
            Civilians.SetActive(true);
        }
        if (Puzzle3)
        {
            Tasks.text = " ";
            GameOverText.text = "Congratulations";
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        CivilianAnimation[0].SetBool("Win", true);
        CivilianAnimation[1].SetBool("Win", true);
        CivilianAnimation[2].SetBool("Win", true);

        yield return new WaitForSeconds(1f);
        GameOverPanel.SetActive(true);
    }

    public void OnResetButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void ToggleSFXButton()
    {
        IsSoundOn = !IsSoundOn;
        AudioCam.GetComponent<AudioListener>().enabled = IsSoundOn;
    }
    public void PauseButton()
    {
        instruction = false;
        IsPaused = false;
        PausePanel.SetActive(false);
    }
    public void InstructionsButton()
    {
        instruction = !instruction;
        InstructionsPanel.SetActive(instruction);
    }
}