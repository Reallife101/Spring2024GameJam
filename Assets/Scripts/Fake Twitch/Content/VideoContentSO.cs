using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoSO", menuName = "ContentSO/Video")]
public class VideoContentSO : ContentSO
{
    public VideoClip clip;

    public override void GetContent()
    {
        ContentManager cm = ContentManager.Instance;
        if (cm)
        {
            cm.PlayVideo(clip);

        }
        else
        {
            ContentIntroManager.Instance.PlayVideo(clip);

        }
    }
}
