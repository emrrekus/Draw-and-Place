using System;
using System.Collections;
using System.Collections.Generic;
using EKLibrary;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public bool Settle;
    [SerializeField] private int LineIndex;

    private void Update()
    {
        if (Settle)
        {
            if (Vector2.Distance(transform.position, General._GameManager._LineCreates[0].GiveLastPosition()) > .1f)
                transform.position = Vector2.Lerp(transform.position,General._GameManager._LineCreates[0].GiveLastPosition(),.2f);
            else
                transform.position = Vector2.Lerp(transform.position,General._GameManager._LineCreates[0].GiveNextPosition(),.2f);
            

        }
    }
}
