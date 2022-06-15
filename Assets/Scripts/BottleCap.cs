using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BottleCap : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float initialXPos = transform.position.x;
            transform.DOMove(new Vector3(initialXPos - 1f, transform.position.y, transform.position.z), 0.5f);
        }
    }
}
