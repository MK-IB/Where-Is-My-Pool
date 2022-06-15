using System;
using System.Collections;
using System.Collections.Generic;
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

    public Animator manAnimator;
    public GirlsReaction[] girlsReactions;

    private float particleCounter = 0;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            //other.gameObject.GetComponent<Collider2D>().enabled = false;
            splashEffect.Play();
            waterLevel.localPosition += new Vector3(0, Time.deltaTime * fillSpeed, 0);
            
            particleCounter++;
            float per = (particleCounter / totalParticles) * 100;
            //print("per = " + per);
            perText.text  = (int)per + "%";
            if(per>30 ) underwaterBubbleEffect.Play();
            if (per == 70)
            {
                for (int i = 0; i < girlsReactions.Length; i++)
                {
                    StartCoroutine(girlsReactions[i].GetIntoThePool());
                }
            }
        }
    }
}