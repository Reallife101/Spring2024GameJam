using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactAudio : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference Happy;
    [SerializeField] FMODUnity.EventReference Sad;
    [SerializeField] FMODUnity.EventReference Bored;
    [SerializeField] FMODUnity.EventReference Angry;

    public void playHappySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(Happy);
    }

    public void playSadSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(Sad);
    }

    public void playBoredSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(Bored);
    }

    public void playAngrySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(Angry);
    }
}
