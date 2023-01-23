using System;
using System.Collections;
using System.Collections.Generic;
using EKLibrary;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LineCreate[] _LineCreates;
    private General _general;
    [SerializeField] private int _ToplamObjectCount;

    private bool StartedTime;
    private int _TotalSocketCount;
    private void Awake()
    {
        _general = new General(this);
        _TotalSocketCount= _ToplamObjectCount;
    }

  

    private void Begin()
    {
        foreach (var item in _LineCreates)
        {
            item.Begin();
            
        }
    }

    public void LineFinish()
    {
        _ToplamObjectCount--;
        if (_ToplamObjectCount == 0)
        {
            Begin();
        }
    }
    public void SocketFinish()
    {
        _TotalSocketCount--;
        if (!StartedTime)
        {
            Invoke("SocketController",2f);
            StartedTime = true;
        }
        if (_TotalSocketCount==0)
        {
            Win();
        }
    }

    private void Win()
    { 
        Debug.Log("Winner");
    }

    void SocketController()
    {
        if (_TotalSocketCount!=0)
        {
            Lose();
        }
    }

    private void Lose()
    {
        Debug.Log("Defeat");
    }
}