using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;

    public AudioSource clipSource;
    public AudioSource dragClipSource;

    public AudioClip holdStart;
    public AudioClip holdRelease;
    public AudioClip waterPouring;
    public AudioClip waterSplash;
    public AudioClip pop;
    
    [Space(20)]
    public AudioClip girlsReactionGood;
    public AudioClip girlsReactionBad;
    public AudioClip confettiBlast;
    public AudioClip fail;

    private void Awake()
    {
        instance = this;
    }

    public void PlayClip(AudioClip clip)
    {
        clipSource.PlayOneShot(clip);
    }
}
