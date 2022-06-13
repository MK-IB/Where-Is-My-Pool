using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class WaterLevel : MonoBehaviour
{
    public Transform waterLevel;
    public float fillSpeed;
    public ParticleSystem splashEffect;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            print("collision 2d");
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            //splashEffect.transform.position = other.transform.position;
            splashEffect.Play();
            waterLevel.localPosition += new Vector3(0, Time.deltaTime * fillSpeed, 0);
            //FindObjectOfType<Water2D_Spawner>().
        }
    }
}