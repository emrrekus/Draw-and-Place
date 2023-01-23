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
    private void Update()
    {
        if (Settle)
        {
            if (Vector2.Distance(transform.position, General._GameManager._LineCreates[LineIndex].GiveLastPosition()) > .1f)
                transform.position = Vector2.Lerp(transform.position,General._GameManager._LineCreates[LineIndex].GiveLastPosition(),.2f);
            else
                transform.position = Vector2.Lerp(transform.position,General._GameManager._LineCreates[LineIndex].GiveNextPosition(),.2f);
            

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(_socketColor))
        {
            Debug.Log("Doğru" + _socketColor);
        }
        else if (col.CompareTag("Socket"))
        {
            Debug.Log("Başka sokete Çarptı");
            Settle = false;
        }
        else
        {
            if(! col.CompareTag(General._GameManager._LineCreates[LineIndex]._Tag))
            Debug.Log("Game Over"+col.gameObject.name);
        }
    }
}
