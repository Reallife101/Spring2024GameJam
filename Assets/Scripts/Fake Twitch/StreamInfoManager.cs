using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StreamInfoManager : MonoBehaviour
{
    [SerializeField]
    private List<TwitchInfoSO> twitchInfos;
    [SerializeField]
    private TMP_Text username;
    [SerializeField]
    private TMP_Text streamInfo;
    [SerializeField]
    private TMP_Text category;

    void Start()
    {
        TwitchInfoSO tiso = twitchInfos[Random.Range(0, twitchInfos.Count)];
        username.text = tiso.streamerName;
        streamInfo.text = tiso.streamInfo;
        category.text = tiso.category;

    }


}
