using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StreamInfoManager : MonoBehaviour
{
    [SerializeField]
    private List<TwitchInfoSO> twitchInfos;
    [SerializeField]
    private List<TMP_Text> username;
    [SerializeField]
    private TMP_Text streamInfo;
    [SerializeField]
    private TMP_Text category;

    void Start()
    {
        TwitchInfoSO tiso = twitchInfos[Random.Range(0, twitchInfos.Count)];
        foreach (TMP_Text t in username)
        {
            t.text = tiso.streamerName;
        }
        streamInfo.text = tiso.streamInfo;
        category.text = tiso.category;

    }


}
