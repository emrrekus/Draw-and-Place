using System;
using System.Collections;
using System.Collections.Generic;
using Example1;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DrawCreate[] _DrawCreates;

    private GenaralManagement _genaralManagement;

    private void Awake()
    {
        _genaralManagement = new(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var item in _DrawCreates)
            {
                item.Begin();
            }
        }
    }
}


