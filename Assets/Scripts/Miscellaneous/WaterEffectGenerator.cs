using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WaterEffectGenerator : MonoBehaviour
{
    int particleCounter;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            particleCounter++;
            if (particleCounter >= 10)
            {
                GameObject steamFx = Instantiate(EffectsManager.instance.steamFx, other.transform.position,
                    quaternion.identity);
                ParticleFollower particleFollower = steamFx.GetComponent<ParticleFollower>();
                particleFollower.target = other.transform;
                particleCounter = 0;
            }
        }
    }
}
