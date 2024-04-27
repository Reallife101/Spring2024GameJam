using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ContentManager : MonoBehaviour
{
    [SerializeField] Image contentImage;
    [SerializeField] VideoPlayer videoPlayer;

    [SerializeField] List<ContentSO> contentList = new List<ContentSO>();

    public static ContentManager Instance { get; private set; }
    ContentSO currentContent = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        chooseNewContent();
    }

    public void PlayVideo(VideoClip clip)
    {
        contentImage.gameObject.SetActive(false);
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

    public void DisplayImage(Sprite image)
    {
        videoPlayer.Stop();
        contentImage.gameObject.SetActive(true);
        videoPlayer.gameObject.SetActive(false);
        contentImage.sprite = image;
    }

    public void chooseNewContent()
    {
        //Get a random one and ask it to call either play video or display image
        currentContent = contentList[Random.Range(0, contentList.Count)];
        currentContent.GetContent();
    }

    //Hook up this function to the emote buttons
    public void ChooseEmote(EmoteEnum emoteType)
    {
        int score = currentContent.GetScore(emoteType);
        pointManager.PM_Instance.GainPoint(score);
        //Choose new emote
        chooseNewContent();
    }

    public void Happy()
    {
        ChooseEmote(EmoteEnum.Happy);
    }

    public void Sad()
    {
        ChooseEmote(EmoteEnum.Sad);
    }

    public void Angry()
    {
        ChooseEmote(EmoteEnum.Angry);
    }

    public void Bored()
    {

    }
}
