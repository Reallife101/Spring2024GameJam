using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoSO", menuName = "ContentSO/Video")]
public class VideoContentSO : ContentSO
{
    [SerializeField] VideoClip clip;

    public override void GetContent()
    {
        ContentManager.Instance.PlayVideo(clip);
    }
}
