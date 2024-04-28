using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject howToPlay;
    [SerializeField]
    private GameObject credits;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject whiteFilter;

    private void Start()
    {
        ShowMainMenu();
    }


    public void ShowMainMenu()
    {
        credits.SetActive(false);
        howToPlay.SetActive(false);
        mainMenu.SetActive(true);
        whiteFilter.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        credits.SetActive(false);
        howToPlay.SetActive(true);
        mainMenu.SetActive(false);
        whiteFilter.SetActive(true);

    }

    public void ShowCredits()
    {
        credits.SetActive(true);
        howToPlay.SetActive(false);
        mainMenu.SetActive(false);
        whiteFilter.SetActive(true);

    }

    public void PlayGame()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
