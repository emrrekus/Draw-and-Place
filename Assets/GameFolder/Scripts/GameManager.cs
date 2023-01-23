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

    private void Awake()
    {
        _general = new General(this);
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
}