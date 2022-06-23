using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnMouse : MonoBehaviour
{
    public float speed;

    private void OnMouseDown()
    {
        if(Hints.instance) Hints.instance.HideHints();
    }

    private void OnMouseDrag()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
