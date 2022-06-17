using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotWaterMaker : MonoBehaviour
{
    public Color hotColor;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = hotColor;
        }
    }
}
