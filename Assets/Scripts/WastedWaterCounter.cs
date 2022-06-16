using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WastedWaterCounter : MonoBehaviour
{
   private int counter;
   
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

   IEnumerator LevelFailed()
   {
      if(!failCalled);
      {
         failCalled = true;
         yield return new WaitForSeconds(2.5f);
         UIManager.instance.failCanvas.SetActive(true);
      }
   }
}
