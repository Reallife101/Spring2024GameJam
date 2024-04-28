using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StreamEnd : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private float timeUntilStreamEnd;
    [SerializeField] private TMP_Text timeLeftText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private string mainMenuName;
    [SerializeField] FMODUnity.EventReference winsfx;
    private bool winhasplayed;
    void Start()
    {
        winhasplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilStreamEnd -= Time.deltaTime;
        timeLeftText.text = ((int)timeUntilStreamEnd).ToString();
        if(timeUntilStreamEnd < 0)
        {
            scoreText.text = "Final Viewer Count: " + pointManager.PM_Instance.totalPoints.ToString();
            animator.SetTrigger("End");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("win", 1);
            if (!winhasplayed)
            {
                FMODUnity.RuntimeManager.PlayOneShot(winsfx);
                winhasplayed = true;
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
    }
}
