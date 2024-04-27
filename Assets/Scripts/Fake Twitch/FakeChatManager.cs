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
    private List<Color> usernameColors = new List<Color>();

    private void Start()
    {
        maxMessages = verticalLayoutChat.childCount;

        for (int i = 0; i < maxMessages; i++)
        {
            // Add the child to the list
            messageBoxes.Add(verticalLayoutChat.GetChild(i).GetComponent<message>());
            messageQueue.Add(emptySO);
            usernameColors.Add(GetRandomColor());
        }

        UpdateChatDisplay();
    }

    public void AddMessage(MessageSO message)
    {
        messageQueue.Add(message);
        usernameColors.Add(GetRandomColor());
        if (messageQueue.Count > maxMessages)
        {
            messageQueue.RemoveAt(0);
            usernameColors.RemoveAt(0);

        }

        UpdateChatDisplay();
    }

    private void UpdateChatDisplay()
    {
        for (int i = 0; i < maxMessages; i++)
        {
            // Add the child to the list
            messageBoxes[i].SetCurrentMessage(messageQueue[i]);
            messageBoxes[i].SetUsernameColor(usernameColors[i]);
            messageBoxes[i].InitializeMessage();
        }

    }

    private Color GetRandomColor()
    {
        // Generate random values for red, green, and blue components
        float randomRed = Random.value;     // Random value between 0.0 and 1.0
        float randomGreen = Random.value;
        float randomBlue = Random.value;

        // Create a color with the random values
        Color randomColor = new Color(randomRed, randomGreen, randomBlue);

        return randomColor;
    }
}
