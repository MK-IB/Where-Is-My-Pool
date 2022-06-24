using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WastedWaterCounter : MonoBehaviour
{
   public static WastedWaterCounter instance;
   private int counter;

   private void Awake()
   {
      instance = this;
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.layer == 4)
      {
         other.gameObject.SetActive(false);
         counter++;
         if (counter >= 45)
         {
            StartCoroutine(LevelFailed());
         }
      }
   }

   private bool failCalled;

   public IEnumerator LevelFailed()
   {
      if(!failCalled && !InGameManager.instance.gameOver)
      {
         failCalled = true;
         InGameManager.instance.gameOver = true;
         yield return new WaitForSeconds(2.5f);
         UIManager.instance.failCanvas.SetActive(true);
         SoundsManager.instance.PlayClip(SoundsManager.instance.fail);
      }
   }
}
