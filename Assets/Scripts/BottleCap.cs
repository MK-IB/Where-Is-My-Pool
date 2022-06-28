using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BottleCap : MonoBehaviour
{
    public bool moveRight;
    private int moveValue;
    
    void Start()
    {
        if (moveRight) moveValue = 5;
        else moveValue = -5;

        Transform myParent = transform.parent;
        myParent.position = new Vector3(myParent.position.x, 9.22f, myParent.position.z);
    } 

    private void OnMouseDown()
    {
        float initialXPos = transform.position.x;
        transform.DOMove(new Vector3(initialXPos + moveValue, transform.position.y, transform.position.z), 1f);
        
        SoundsManager.instance.PlayClip(SoundsManager.instance.pop);
        DOVirtual.DelayedCall(1.5f, () =>
        {
            SoundsManager.instance.PlayClip(SoundsManager.instance.waterPouring);
        });
    }
}
