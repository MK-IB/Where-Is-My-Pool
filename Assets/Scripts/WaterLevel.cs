using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Water2D;

public class WaterLevel : MonoBehaviour
{
    public Transform waterLevel;

    public Water2D_Spawner water2DSpawner;
    public float fillSpeed;
    public TextMeshPro perText;
    public float totalParticles;
    public ParticleSystem splashEffect;
    public ParticleSystem underwaterBubbleEffect;
    public ParticleSystem steamEffect;
    public GameObject winConfettiBlast;
    public GirlsReaction[] girlsReactions;

    private float particleCounter = 0;

    private void Start()
    {
        totalParticles = water2DSpawner.DropCount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            splashEffect.Play();
            waterLevel.localPosition += new Vector3(0, Time.deltaTime * fillSpeed, 0);
            
            particleCounter++;
            float per = (particleCounter / totalParticles) * 100;
            //print("per = " + per);
            perText.text  = (int)per + "%";
            if(per>30 )
            {
                underwaterBubbleEffect.Play();
                steamEffect.Play();
            }
            if (per >= 55)
            {
                EnoughWaterReached();
            }
        }
    }

    private bool _enoughReached;
    void EnoughWaterReached()
    {
        if (_enoughReached || InGameManager.instance.gameOver) return;
        
        _enoughReached = true;
        InGameManager.instance.gameOver = true;
        for (int i = 0; i < girlsReactions.Length; i++)
        {
            StartCoroutine(girlsReactions[i].GetIntoThePool());
        }

        DOVirtual.DelayedCall(3.5f, () =>
        {
            winConfettiBlast.SetActive(true);
            InGameManager.instance.StartCoroutine(InGameManager.instance.WinEffects());
        });
    }
}