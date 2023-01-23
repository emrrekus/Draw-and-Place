using System;
using System.Collections;
using System.Collections.Generic;
using EKLibrary;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public bool Settle;
    [SerializeField] private int LineIndex;
    [SerializeField] private string _socketColor;

    private bool _Nest;
    private Vector2 _NestPosition;
    [SerializeField] private GameObject _FinishNest;
    private void Update()
    {
        if (Settle)
        {
            if (Vector2.Distance(transform.position, General._GameManager._LineCreates[LineIndex].GiveLastPosition()) > .1f)
                transform.position = Vector2.Lerp(transform.position,General._GameManager._LineCreates[LineIndex].GiveLastPosition(),.2f);
            else
                transform.position = Vector2.Lerp(transform.position,General._GameManager._LineCreates[LineIndex].GiveNextPosition(),.2f);
            

        }

        if (_Nest)
        {
            if (Vector2.Distance(transform.position, _NestPosition) > .1f)
                transform.position = Vector2.Lerp(transform.position, _NestPosition, .2f);
            else
            {
                transform.position = _NestPosition;
                _Nest = false; 
            }
                
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(_socketColor))
        {
            Debug.Log("Doğru" + _socketColor);
            _Nest = true;
            _NestPosition = _FinishNest.transform.position;
            
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (col.CompareTag("Socket"))
        {
            Debug.Log("Başka sokete Çarptı");
            Settle = false;
        }
        else
        {
            if (!col.CompareTag(General._GameManager._LineCreates[LineIndex]._Tag))
            {
                Settle = false;
            }
            
        }
    }
}
