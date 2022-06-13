using System.Collections;
using System.Collections.Generic;
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
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
