using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CutTheRope {

   
   public class CharacterLogic : MonoBehaviour {


      public Action OnBallEnter;

      private void OnTriggerEnter2D(Collider2D col) {
         if (col.CompareTag("Ball")) {
            Destroy(col.gameObject);
            OnBallEnter?.Invoke();
         }
      }

   }

}
