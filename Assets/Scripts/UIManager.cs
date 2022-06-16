using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    public GameObject winCanvas;
    public GameObject failCanvas;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }
}
