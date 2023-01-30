using System;
using System.Collections;
using System.Collections.Generic;
using EKLibrary;
using UnityEditor;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public List<LineCreate> _LineCreates;
    private General _general;
    [SerializeField] private int _ToplamObjectCount;

    private bool StartedTime;
    private int _TotalSocketCount;

    
    [SerializeField] private List<OtomaticLevel> _otomaticLevels;
    
    private void Awake()
    {
        _general = new General(this);
        _TotalSocketCount= _ToplamObjectCount;
    }

    private void Start()
    {
        for (int i = 0; i <_otomaticLevels[0]._entryObjects.Count; i++)
        {
            _otomaticLevels[0]. _entryObjects[i]._EntryObject.tag = "Entry" + (i + 1);
            _otomaticLevels[0]. _sockets[i]._Socket.transform.position = _otomaticLevels[0]._entryObjects[i]._SocketEntryPosition.transform.position;
            _otomaticLevels[0]._sockets[i]._SpriteRenderer.color = _otomaticLevels[0]._sockets[i]._color;
            _otomaticLevels[0]. _sockets[i]._Socket.LineIndex = i;
            _otomaticLevels[0]. _sockets[i]._Socket._socketColor =_otomaticLevels[0]. _sockets[i]._SocketColor;

            _otomaticLevels[0]. _sockets[i]._FinishNestSpriyeRenderer.gameObject.tag = _otomaticLevels[0]._sockets[i]._SocketColor;
            _otomaticLevels[0]. _sockets[i]._FinishNestSpriyeRenderer.color = _otomaticLevels[0]._sockets[i]._color;
            _otomaticLevels[0].  _sockets[i]._Socket._FinishNest= _otomaticLevels[0]._sockets[i]._FinishNestCenter;
            
            _otomaticLevels[0]. _lineRenderers[i].startColor= _otomaticLevels[0]._sockets[i]._color;
            _otomaticLevels[0].  _lineRenderers[i].endColor=_otomaticLevels[0]. _sockets[i]._color;

            LineCreate _Lc = gameObject.AddComponent<LineCreate>();
            _Lc._LineRenderer = _otomaticLevels[0]._lineRenderers[i];
            _Lc._Socket = _otomaticLevels[0]._sockets[i]._Socket;
            _Lc._Tag="Entry" + (i + 1);
            
            _LineCreates.Add(_Lc);
        }
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