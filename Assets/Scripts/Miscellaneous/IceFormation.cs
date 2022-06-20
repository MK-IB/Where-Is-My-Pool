using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class IceFormation : MonoBehaviour
{
    public static IceFormation instance;
    
    public List<Transform> iceSpikes;
    public GameObject snowFx;

    private void Awake()
    {
        instance = this;
    }

    public void ShowSnowSpikes()
    {
        snowFx.SetActive(true);
        for (int i = 0; i < iceSpikes.Count; i++)
        {
            iceSpikes[i].gameObject.SetActive(true);
            iceSpikes[i].DOScale(Vector3.zero, 0.5f).From();
            float randAngle = Random.Range(0, 180);
            iceSpikes[i].DORotate(new Vector3(randAngle, randAngle, randAngle), 0.5f).From();
        }
    }
}
