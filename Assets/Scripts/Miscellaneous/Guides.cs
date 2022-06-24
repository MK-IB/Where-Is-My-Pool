using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Guides : MonoBehaviour
{
    public SpriteRenderer handGuide;
    public TextMeshPro textGuide;
    public SpriteRenderer arrowGuide;

    public void ShowNextGuide()
    {
        handGuide.DOFade(0, 0.5f).OnComplete(() =>
        {
            handGuide.gameObject.SetActive(false);
            textGuide.DOColor(new Color(255, 255, 255, 1), 0.5f);
            arrowGuide.DOFade(1, 0.5f);
        });
    }

    public void DisableAllGuides()
    {
        textGuide.DOColor(new Color(0, 0, 0, 0), 0.5f);
        DOTween.Kill(arrowGuide);
        arrowGuide.GetComponent<SpriteRenderer>().enabled = false;
    }
    

}
