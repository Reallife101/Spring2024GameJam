using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StreamEnd : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private float timeUntilStreamEnd;
    [SerializeField] private TMP_Text timeLeftText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilStreamEnd -= Time.deltaTime;
        timeLeftText.text = ((int)timeUntilStreamEnd).ToString();
        if(timeUntilStreamEnd < 0)
        {
            animator.SetTrigger("End");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Time.timeScale = 0;
        }
    }
}