using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Video;

public class ContentManager : MonoBehaviour
{
    [SerializeField] Image contentImage;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] private float emoteCooldown;
    [SerializeField] Donation donationScript;
    [SerializeField] List<ContentSO> contentList = new List<ContentSO>();
    [SerializeField] ReactiveChatManager rcm;
    [SerializeField] Animator streamerAnim;
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
        if (rcm != null && score > 0)
        {
            rcm.SpamPositiveMessages();
        }
        else
        {
            rcm.SpamNegativeMessages();
        }
        //Choose new emote
        chooseNewContent();
    }

    public void Happy()
    {
        if(donationScript.donoActive)
        {
            pointManager.PM_Instance.GainPoint(1);
        }
        else
        {
            ChooseEmote(EmoteEnum.Happy);
        }
        streamerAnim.SetTrigger("Happy");
        
    }

    public void Sad()
    {
        if (donationScript.donoActive)
        {

        }
        else
        {
            ChooseEmote(EmoteEnum.Sad);
        }
        streamerAnim.SetTrigger("Sad");
    }

    public void Angry()
    {
        if (donationScript.donoActive)
        {

        }
        else
        {
            ChooseEmote(EmoteEnum.Angry);
        }
        streamerAnim.SetTrigger("Angry");
    }

    public void Bored()
    {
        if (donationScript.donoActive)
        {

        }
        else
        {
            ChooseEmote(EmoteEnum.Bored);
        }
        streamerAnim.SetTrigger("Bored");
    }
}
