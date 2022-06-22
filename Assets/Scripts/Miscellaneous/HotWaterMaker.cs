using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotWaterMaker : MonoBehaviour
{
    public static HotWaterMaker instance;
    
    public Color hotColor;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            other.gameObject.tag = "Hot_particle";
            other.gameObject.GetComponent<SpriteRenderer>().color = hotColor;
        }

        if (other.gameObject.CompareTag("steam"))
        {
            print("steam collision");
            other.gameObject.SetActive(false);
        }
    }
}
