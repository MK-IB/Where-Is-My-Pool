using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [Header("CANVASES")]
    public GameObject winCanvas;
    public GameObject failCanvas;

    [Header("UIs")]
    public TextMeshProUGUI levelNumText;

    public GameObject hintButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        levelNumText.SetText("Lv." + (SceneManager.GetActiveScene().buildIndex + 1));
        //if(SceneManager.GetActiveScene().buildIndex == 1) hintButton.SetActive(false);
    }

    public void OnHintButtonPressed()
    {
        Hints.instance.ShowHints();
    }
}
