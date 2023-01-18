using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCreate : MonoBehaviour
{
    public LineRenderer _LineRenderer;
    public List<Vector2> HandPositionList;
    public Socket _Socket;

    private Camera _camera;

    private void Update()
    {
        _camera = Camera.main;
        
        if (Input.GetMouseButtonDown(0))
        {
            DrawCreatee();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 HandPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(HandPosition, HandPositionList[^1]) > .1f)
            {
                DrawUpdate(HandPosition);
            }
        }
    }

    private void DrawUpdate(Vector2 HandPosition)
    {
        HandPositionList.Add(HandPosition);
        _LineRenderer.positionCount++;
        _LineRenderer.SetPosition(_LineRenderer.positionCount-1,HandPosition);
    }

    private void DrawCreatee()
    {
        HandPositionList.Add(_camera.ScreenToWorldPoint(Input.mousePosition));
        HandPositionList.Add(_camera.ScreenToWorldPoint(Input.mousePosition));
        
        _LineRenderer.SetPosition(0,HandPositionList[0]);
        _LineRenderer.SetPosition(1,HandPositionList[1]);
    }
}
