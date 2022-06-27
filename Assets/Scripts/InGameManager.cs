using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Water2D;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;
    public bool gameOver;
    public bool isHotWaterLevel;
    public Color hotWaterBlue;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //isHotWaterLevel = true;
    }

    private void Update()
    {
        
    }
    
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("level", 1) >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings - 1));
            PlayerPrefs.SetInt("level", (PlayerPrefs.GetInt("level", 1) + 1));
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("level", (PlayerPrefs.GetInt("level", 1) + 1));
        }
        PlayerPrefs.SetInt("levelnumber", PlayerPrefs.GetInt("levelnumber", 1) + 1);
    }

    public IEnumerator WinEffects()
    {
        Camera effectCamera = ReferenceBank.instance.effectCamera;
        Camera defaultCamera = ReferenceBank.instance.defaultCamera;

        Vector3 camOrigPos = effectCamera.transform.position;
        Transform tubTransform = ReferenceBank.instance.bathTub.transform;
        
        Vector3 newPos = new Vector3(tubTransform.position.x, tubTransform.position.y, camOrigPos.z);
        effectCamera.transform.DOMove(newPos, 1.5f);
        defaultCamera.transform.DOMove(newPos, 1.5f);

        effectCamera.GetComponent<Camera>().DOOrthoSize(5, 1.5f);
        defaultCamera.GetComponent<Camera>().DOOrthoSize(5, 1.5f);
        
        yield return new WaitForSeconds(2);
        UIManager.instance.winCanvas.SetActive(true);
    }
}
