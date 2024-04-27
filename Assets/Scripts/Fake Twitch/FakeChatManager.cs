using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeChatManager : MonoBehaviour
{

    [SerializeField]
    private Transform verticalLayoutChat;
    [SerializeField]
    private MessageSO emptySO;

    private int maxMessages = 35;

    private List<MessageSO> messageQueue = new List<MessageSO>();
    private List<message> messageBoxes = new List<message>();

    private void Start()
    {
        maxMessages = verticalLayoutChat.childCount;

        for (int i = 0; i < maxMessages; i++)
        {
            // Add the child to the list
            messageBoxes.Add(verticalLayoutChat.GetChild(i).GetComponent<message>());
            messageQueue.Add(emptySO);
        }

        UpdateChatDisplay();
    }

    public void AddMessage(MessageSO message)
    {
        messageQueue.Add(message);
        if (messageQueue.Count > maxMessages)
        {
            messageQueue.RemoveAt(0);
        }

        UpdateChatDisplay();
    }

    private void UpdateChatDisplay()
    {
        for (int i = 0; i < maxMessages; i++)
        {
            // Add the child to the list
            messageBoxes[i].SetCurrentMessage(messageQueue[i]);
            messageBoxes[i].InitializeMessage();
        }

    }
}
