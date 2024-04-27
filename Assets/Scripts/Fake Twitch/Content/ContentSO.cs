using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public enum EmoteEnum
{
    Happy,
    Sad,
    Bored,
    Angry
}


[Serializable]
public class EmoteScoreDict : SerializableDictionary<EmoteEnum, float> {}

public abstract class ContentSO : ScriptableObject
{
    [SerializeField] private EmoteScoreDict emoteMap;

    public float GetScore(EmoteEnum emote)
    {
        //If doesnt exist, do nothing
        if (!emoteMap.ContainsKey(emote))
        {
            return 0;
        }
        return emoteMap[emote];
    }

    public abstract void GetContent();
}
