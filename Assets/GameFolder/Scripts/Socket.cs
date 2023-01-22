using System;
using System.Collections;
using System.Collections.Generic;
using Example1;
using UnityEngine;


public class Socket : MonoBehaviour
{
   public bool Settle;
   [SerializeField] private int DrawIndex;

   private void Update()
   {
      if (Settle)
      {
         if (Vector2.Distance(transform.position, GenaralManagement._GameManager._DrawCreates[DrawIndex].GiveLastPosition())> .1f)
            transform.position=Vector2.Lerp(transform.position,GenaralManagement._GameManager._DrawCreates[DrawIndex].GiveLastPosition(),.2f);
         else
            transform.position=Vector2.Lerp(transform.position,GenaralManagement._GameManager._DrawCreates[DrawIndex].GiveNextPosition(),.2f);
      }
   }
}
