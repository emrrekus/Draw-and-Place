using System;
using System.Collections;
using System.Collections.Generic;
using EKLibrary;
using UnityEditor;
using UnityEngine;

[Serializable]
public class EntryObjects
{
    public GameObject _EntryObject;
    public GameObject _SocketEntryPosition;


}
[Serializable]
public class Sockets
{
    public Color _color;
    public SpriteRenderer _SpriteRenderer;

    [Header("----Soket Script İşlemleri")] 
    public Socket _Socket;

    public string _SocketColor;
    public SpriteRenderer _FinishNestSpriyeRenderer;
    public GameObject _FinishNestCenter;



}

public class GameManager : MonoBehaviour
{
    public LineCreate[] _LineCreates;
    private General _general;
    [SerializeField] private int _ToplamObjectCount;

    private bool StartedTime;
    private int _TotalSocketCount;

    [SerializeField] private List<EntryObjects> _entryObjects;
    [SerializeField] private List<Sockets> _sockets;
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