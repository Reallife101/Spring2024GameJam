using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ImageSO", menuName = "ContentSO/Image")]
public class ImageContentSO : ContentSO
{
    public Sprite image;

    public override void GetContent()
    {
        ContentManager cm = ContentManager.Instance;
        if (cm)
        {
            cm.DisplayImage(image);

        }
        else
        {
            ContentIntroManager.Instance.DisplayImage(image);

        }
    }

}
