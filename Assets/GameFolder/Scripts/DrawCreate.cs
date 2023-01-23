using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCreate : MonoBehaviour
{
    public LineRenderer _LineRenderer;
    public List<Vector2> HandPositionList;
    public Socket _Socket;
    public string _Tag;

    private Camera _camera;
    private bool Draw;
    private int _HandPositionIndex;

    private RaycastHit2D _hit;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        
        
     

        if (Input.GetMouseButton(0)&& Draw)
        {
            Vector2 HandPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(HandPosition, HandPositionList[^1]) > .1f)
            {
                DrawUpdate(HandPosition);
            }
        }

        _hit = Physics2D.Raycast(
           _camera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10)), Vector2.zero);
       if (_hit.collider != null)
       {
           if (_hit.collider.gameObject.CompareTag(_Tag) && !Draw && Input.GetMouseButtonDown(0))
           {
               DrawCreatee();
               Draw = true;
           }
       }

        if (Input.GetMouseButtonUp(0) && Draw)
        {
            enabled = false;

        }
    }

    public void Begin()
    {
        _Socket.Settle = true;
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
}
