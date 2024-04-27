using UnityEngine;

[CreateAssetMenu(fileName = "New Message", menuName = "Chat System/Message")]
public class MessageSO : ScriptableObject
{
    public string senderName;
    public string content;
    public Color nameColor;
}
