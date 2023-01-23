using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class LineCreate : MonoBehaviour
{
   public LineRenderer _LineRenderer;
   public List<Vector2> HandPositionList;
   public Socket _Socket;

   private int _HandPositionIndex;
   Camera _camera;
   private void Start()
   {
      _camera = Camera.main;
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         LineCreator();
      }

      if (Input.GetMouseButton(0))
      {
         Vector2 HandPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

         if (Vector2.Distance(HandPosition, HandPositionList[^1]) > .1f)
         {
            LineUpdate(HandPosition);
         }
      }
   }

   private void LineUpdate(Vector2 handPosition)
   {
      HandPositionList.Add(handPosition);
      _LineRenderer.positionCount++;
      _LineRenderer.SetPosition(_LineRenderer.positionCount-1,handPosition);
   }

   private void LineCreator()
   {
      HandPositionList.Add(_camera.ScreenToWorldPoint(Input.mousePosition));
      HandPositionList.Add(_camera.ScreenToWorldPoint(Input.mousePosition));
      
      _LineRenderer.SetPosition(0,HandPositionList[0]);
      _LineRenderer.SetPosition(1,HandPositionList[1]);
   }

   public Vector2 GiveLastPosition()
   {
      return HandPositionList[_HandPositionIndex];
   }

   public Vector2 GiveNextPosition()
   {
      if (_HandPositionIndex == HandPositionList.Count - 1)
      {
         _Socket.Settle = false;
         return HandPositionList[_HandPositionIndex];
      }
      else
      {
         _HandPositionIndex++;
         return HandPositionList[_HandPositionIndex];
      }
     
   }

   public void Begin()
   {
      _Socket.Settle = true;
   }
}
