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

    private void Awake()
    {
        _general = new General(this);
    }

    private void Start()
    {
        
    }
}


