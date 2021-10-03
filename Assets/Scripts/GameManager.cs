using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float BoxCollected;
    public float ZombiesKilled;

    public GameObject Boxes;
    public int BoxCount;

    public int ZombieCount;

    public Text ScoreText;
    public GameObject ScorePanel;

    public bool Puzzle1, Puzzle2, Puzzle3;

    void Start()
    {
        Puzzle1 = false;
        Puzzle2 = false;
        Puzzle3 = false;
        BoxCollected = 0;
        ScorePanel.SetActive(true);
    }

    void Update()
    {
        ScoreText.text = "Collected = " + BoxCollected;

        if(BoxCollected >= BoxCount)
        {
            Puzzle1 = true;
        }
        if(ZombiesKilled >= ZombieCount)
        {
            Puzzle3 = true;
        }
    }
}