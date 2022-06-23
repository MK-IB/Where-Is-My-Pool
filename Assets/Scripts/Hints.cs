using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hints : MonoBehaviour
{
   public static Hints instance;
   public List<GameObject> relatedMovables;

   private void Awake()
   {
      instance = this;
   }

   public void ShowHints()
   {
      for (int i = 0; i < transform.childCount; i++)
      {
         transform.GetChild(i).gameObject.SetActive(true);
      }
   }

   public void HideHints()
   {
      for (int i = 0; i < transform.childCount; i++)
      {
         DOTween.Kill(transform.GetChild(i));
         transform.GetChild(i).gameObject.SetActive(false);
      }
   }
}
