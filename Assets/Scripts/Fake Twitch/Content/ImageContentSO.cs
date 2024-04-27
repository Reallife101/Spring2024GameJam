using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ImageSO", menuName = "ContentSO/Image")]
public class ImageContentSO : ContentSO
{
    [SerializeField] Sprite image;

    public override void GetContent()
    {
        ContentManager.Instance.DisplayImage(image);
    }

}
