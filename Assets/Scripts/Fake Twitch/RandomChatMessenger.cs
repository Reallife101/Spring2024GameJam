using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChatMessenger : MonoBehaviour
{
    [SerializeField] 
    private FakeChatManager chat;
    [SerializeField]
    private List<MessageSO> messages;

    private void Start()
    {
        // Start all six coroutines
        for (int i = 0; i < 6; i++)
        {
            StartCoroutine(RandomDelayMessage());
        }
    }

    IEnumerator RandomDelayMessage()
    {
        while (true)
        {
            // Generate a random delay between 1 and 5 seconds
            float delay = Random.Range(0.1f, 5f);

            // Wait for the random delay
            yield return new WaitForSeconds(delay);

            SendRandomMessage();
        }
    }

    private void SendRandomMessage()
    {
        chat.AddMessage(messages[Random.Range(0, messages.Count)]);
    }
}
