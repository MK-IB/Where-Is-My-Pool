using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BottleCap : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        float initialXPos = transform.position.x;
        transform.DOMove(new Vector3(initialXPos - 3f, transform.position.y, transform.position.z), 1f);
    }
}
