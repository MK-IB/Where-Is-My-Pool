using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager instance;
    
    public GameObject freezeEmojiReaction;
    public GameObject steamFx;
    public GameObject coldWaterEffect;

    private void Awake()
    {
        instance = this;
    }
}
