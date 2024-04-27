using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(FakeChatManager))]
public class TwitchChatTestTool : Editor
{
    private int dictLength = 1;
    private List<MessageSO> cards = new List<MessageSO>();

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FakeChatManager fakeChatManager = (FakeChatManager)target;

        CreateDictGUI();

        if (GUILayout.Button("AddRandomMessage"))
        {
            AddMessage(fakeChatManager);
        }
    }

    private void CreateDictGUI()
    {
        // Start Dictionary Section
        GUILayout.Space(10f);
        GUILayout.Label("MESSAGE SENDER", EditorStyles.boldLabel);
        dictLength = EditorGUILayout.IntField("Number of Entries:", dictLength);
        GUILayout.Space(7.5f);

        if (dictLength < 0)
        {
            dictLength = 0;
        }

        // Resize fields as necessary
        while (cards.Count < dictLength)
        {
            cards.Add(null);

        }

        while (cards.Count < dictLength)
        {
            cards.RemoveAt(cards.Count - 1);
        }

        // Add slots for additional dictionary items
        for (int i = 0; i < dictLength; i++)
        {
            // Suit selection drop-down
            EditorGUILayout.BeginHorizontal();
            cards[i] = (MessageSO)EditorGUILayout.ObjectField("Select MessageSO:", cards[i], typeof(MessageSO), true);
            EditorGUILayout.EndHorizontal();
        }

    }

    private void AddMessage(FakeChatManager fakeChat)
    {
        fakeChat.AddMessage(cards[Random.Range(0, cards.Count)]);

        // Repaint the inspector to reflect the changes
        Repaint();
    }
}
