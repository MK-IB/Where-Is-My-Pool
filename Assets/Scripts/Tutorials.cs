using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    public GameObject[] girlCallouts;
    public GameObject handHelp;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            handHelp.SetActive(false);
            for (int i = 0; i < girlCallouts.Length; i++)
            {
                girlCallouts[i].SetActive(false);
            }
        }
    }
}
