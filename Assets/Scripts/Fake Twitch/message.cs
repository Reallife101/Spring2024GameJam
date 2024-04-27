using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class message : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    private TextMeshProUGUI username;
    [SerializeField]
    private RectTransform rectTransform;
    private MessageSO currentMessage;

    public static int LINE_BUFFER = 5;

    public MessageSO CurrentMessage
    {
        get { return currentMessage; }
        set
        {
            currentMessage = value;
            InitializeMessage();
        }
    }

    public void SetCurrentMessage(MessageSO msg)
    {
        CurrentMessage = msg;
    }

    public void SetUsernameColor(Color c)
    {
        username.color = c;

    }

    public void InitializeMessage()
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, (textMeshProUGUI.fontSize+ LINE_BUFFER) * GetNumLines());
        
        if (currentMessage != null)
        {
            textMeshProUGUI.text = currentMessage.senderName + ": "+ currentMessage.content;
            username.text = currentMessage.senderName + ": ";
            //username.color = GetRandomColor();
        }
        else
        {
            textMeshProUGUI.text = "";
            username.text = "";
        }
    }

    public int GetNumLines()
    {
        // Calculate the number of lines by dividing the preferred height by the line height
        return Mathf.RoundToInt(textMeshProUGUI.preferredHeight / textMeshProUGUI.fontSize);
    }


}
