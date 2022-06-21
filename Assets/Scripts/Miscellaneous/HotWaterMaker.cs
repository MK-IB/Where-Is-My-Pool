using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotWaterMaker : MonoBehaviour
{
    public Color hotColor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            other.gameObject.tag = "Hot_particle";
            other.gameObject.GetComponent<SpriteRenderer>().color = hotColor;
        }
    }
}
