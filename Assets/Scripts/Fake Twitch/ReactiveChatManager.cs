using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveChatManager : MonoBehaviour
{
    [SerializeField]
    private List<MessageSO> positiveMessages;
    [SerializeField]
    private List<MessageSO> negativeMessages;
    [SerializeField]
    private FakeChatManager chat;

    public void SpamPositiveMessages()
    {
        // Start all six coroutines
        for (int i = 0; i < 6; i++)
        {
            StartCoroutine(RandomDelayMessage(positiveMessages));
        }
    }

    public void SpamNegativeMessages()
    {
        // Start all six coroutines
        for (int i = 0; i < 6; i++)
        {
            StartCoroutine(RandomDelayMessage(negativeMessages));
        }
    }

    IEnumerator RandomDelayMessage(List<MessageSO> msgs)
    {
        for(int i = 0; i < 3; i++)
        {
            float delay = Random.Range(0.1f, 2f);

            // Wait for the random delay
            yield return new WaitForSeconds(delay);

            SendRandomMessage(msgs);
        }
    }

    private void SendRandomMessage(List<MessageSO> msgs)
    {
        chat.AddMessage(msgs[Random.Range(0, msgs.Count)]);
    }

}
