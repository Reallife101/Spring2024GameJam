using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamStart : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start()
    {
        Time.timeScale = 0f;
        StartStream();
    }


    public void StartStream()
    {
        Time.timeScale = 1;
        animator.SetTrigger("Start");
    }
}
