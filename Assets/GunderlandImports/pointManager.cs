using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointManager : MonoBehaviour
{
    public static pointManager PM_Instance;
    public int totalPoints;
    public int numIncorrect;
    public float param;
    [SerializeField] FMODUnity.EventReference correctsfx;
    [SerializeField] FMODUnity.EventReference incorrectsfx; 
    [SerializeField] TMP_Text score;

    private void Awake()
    {
        if(PM_Instance != null)
        {
            Destroy(gameObject);
        }
        PM_Instance = this;
    }

    private void Start()
    {
        totalPoints = 0;
        numIncorrect = 0;
        param = 0;
    }

    public void GainPoint(int points)
    {
        if (points <= 0)
        {
            ++numIncorrect;
            FMODUnity.RuntimeManager.PlayOneShot(incorrectsfx);
        } else if (points > 0)
        {
            numIncorrect = 0;
            FMODUnity.RuntimeManager.PlayOneShot(correctsfx);
        }
        param = (float)(numIncorrect/3.0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("playersucks", param);
            
        
        int pointsGained = (int)(points * comboManager.CM_Instance.currentMultiplier);
        totalPoints += pointsGained;
        comboManager.CM_Instance.GainComboPoints(pointsGained);
        score.text = totalPoints.ToString();
    }
}
