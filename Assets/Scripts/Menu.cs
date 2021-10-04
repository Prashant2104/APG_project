using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject InstructionsPanel;
    public bool instruction = false;
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void InstructionsButton()
    {
        instruction = !instruction;
        InstructionsPanel.SetActive(instruction);
        MainPanel.SetActive(!instruction);
    }
}
