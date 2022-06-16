using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DragGuide : MonoBehaviour
{
    public bool show;
    public Guides guides;

    private void OnMouseDrag()
    {
        if (show)
        {
            guides.ShowNextGuide();
        }else guides.DisableAllGuides();
    }
}
