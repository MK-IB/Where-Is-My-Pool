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
            if (per == 70)
            {
                for (int i = 0; i < girlsReactions.Length; i++)
                {
                    StartCoroutine(girlsReactions[i].GetIntoThePool());
                }

                DOVirtual.DelayedCall(3.5f, () =>
                {
                    winConfettiBlast.SetActive(true);
                    InGameManager.instance.WinEffects();
                });
            }
        }
    }
}