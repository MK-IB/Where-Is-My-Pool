using System.Collections;
using System.Collections.Generic;
using OneSignalSDK;
using UnityEngine;

public class OneSignalScript : MonoBehaviour
{
    void Start()
    {
        OneSignal.Default.Initialize("81bc2f10-0e5d-4718-8c11-3e9ef8ee854d");
        OneSignal.Default.SetExternalUserId("123456789");
    }
}
