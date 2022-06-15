using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceBank : MonoBehaviour
{
    public static ReferenceBank instance;

    public GameObject bathTub;
    public Camera effectCamera;
    public Camera defaultCamera;

    public GameObject boy;

    private void Awake()
    {
        instance = this;
    }
}
