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
    public string tagToCheck;

    private float particleCounter = 0;

    private void Start()
    {
        totalParticles = water2DSpawner.DropCount;
        if(!InGameManager.instance.isHotWaterLevel)
            tagToCheck = "Metaball_liquid";
        else tagToCheck = "Hot_particle";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagToCheck))
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
        else
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
                FreezeTheGirls();
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
            StartCoroutine(girlsReactions[i].GetIntoThePool("swim"));
        }

        DOVirtual.DelayedCall(3.5f, () =>
        {
            winConfettiBlast.SetActive(true);
            InGameManager.instance.StartCoroutine(InGameManager.instance.WinEffects());
        });
    }

    void FreezeTheGirls()
    {
        if (_enoughReached || InGameManager.instance.gameOver) return;
        
        _enoughReached = true;
        InGameManager.instance.gameOver = true;
        IceFormation.instance.ShowSnowSpikes();
        
        for (int i = 0; i < girlsReactions.Length; i++)
        {
            StartCoroutine(girlsReactions[i].GetIntoThePool("freeze"));
        }
        DOVirtual.DelayedCall(5f, () =>
        {
            //winConfettiBlast.SetActive(true);
            UIManager.instance.failCanvas.SetActive(true);
        });
    }
}