using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ContentManager : MonoBehaviour
{
    [SerializeField] Image contentImage;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] private float emoteCooldown;
    [SerializeField] List<ContentSO> contentList = new List<ContentSO>();
    float currentCooldown = 0;

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

    private void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown > emoteCooldown)
        {
            return;
        }
        currentCooldown = emoteCooldown;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Happy();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Sad();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Bored();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Angry();
        }
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
