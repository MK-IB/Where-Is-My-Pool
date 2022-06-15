using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void WinEffects()
    {
        Camera effectCamera = ReferenceBank.instance.effectCamera;
        Camera defaultCamera = ReferenceBank.instance.defaultCamera;

        Vector3 camOrigPos = effectCamera.transform.position;
        Vector3 newPos = new Vector3(camOrigPos.x, -7, camOrigPos.z);
        effectCamera.transform.DOMove(newPos, 1.5f);
        defaultCamera.transform.DOMove(newPos, 1.5f);

        effectCamera.GetComponent<Camera>().DOOrthoSize(5, 1.5f);
        defaultCamera.GetComponent<Camera>().DOOrthoSize(5, 1.5f);
    }
}
