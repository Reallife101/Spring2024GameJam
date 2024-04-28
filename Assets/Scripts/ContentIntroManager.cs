using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ContentIntroManager : MonoBehaviour
{
    [SerializeField] Image contentImage;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] List<ContentSO> contentList = new List<ContentSO>();

    public bool canChangeContent = true;

    private float timeElapsed = 0f;

    public static ContentIntroManager Instance { get; private set; }
    ContentSO currentContent = null;

    private void Awake()
    {
        if (Instance == null)
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
        canChangeContent = true;
    }

    private void Update()
    {
        if (canChangeContent && timeElapsed>5f)
        {
            timeElapsed = 0f;
            chooseNewContent();            
        }

        timeElapsed += Time.deltaTime;
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

}
