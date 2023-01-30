using System;
using System.Collections;
using System.Collections.Generic;
using EKLibrary;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("General Objects")] public List<LineCreate> _LineCreates;
    [SerializeField] private int _ToplamObjectCount;
    [SerializeField] GameObject[] _panels;
    [SerializeField] private TextMeshProUGUI _PointText;


    [Header("Otomatic Level")] [SerializeField]
    private List<OtomaticLevel> _otomaticLevels;


    private General _general;
    private bool StartedTime;
    private int _TotalSocketCount;
    private int _SceneIndex;

    private void Awake()
    {
        _SceneIndex = SceneManager.GetActiveScene().buildIndex;
        _general = new General(this);
        _TotalSocketCount = _ToplamObjectCount;
        _PointText.text = MemoryManagement.ReadDataInt("Point").ToString();
    }

    private void Start()
    {
        for (int i = 0; i < _otomaticLevels[0]._entryObjects.Count; i++)
        {
            _otomaticLevels[0]._entryObjects[i]._EntryObject.tag = "Entry" + (i + 1);
            _otomaticLevels[0]._sockets[i]._Socket.transform.position =
                _otomaticLevels[0]._entryObjects[i]._SocketEntryPosition.transform.position;
            _otomaticLevels[0]._sockets[i]._SpriteRenderer.color = _otomaticLevels[0]._sockets[i]._color;
            _otomaticLevels[0]._sockets[i]._Socket.LineIndex = i;
            _otomaticLevels[0]._sockets[i]._Socket._socketColor = _otomaticLevels[0]._sockets[i]._SocketColor;

            _otomaticLevels[0]._sockets[i]._FinishNestSpriyeRenderer.gameObject.tag =
                _otomaticLevels[0]._sockets[i]._SocketColor;
            _otomaticLevels[0]._sockets[i]._FinishNestSpriyeRenderer.color = _otomaticLevels[0]._sockets[i]._color;
            _otomaticLevels[0]._sockets[i]._Socket._FinishNest = _otomaticLevels[0]._sockets[i]._FinishNestCenter;

            _otomaticLevels[0]._lineRenderers[i].startColor = _otomaticLevels[0]._sockets[i]._color;
            _otomaticLevels[0]._lineRenderers[i].endColor = _otomaticLevels[0]._sockets[i]._color;

            LineCreate _Lc = gameObject.AddComponent<LineCreate>();
            _Lc._LineRenderer = _otomaticLevels[0]._lineRenderers[i];
            _Lc._Socket = _otomaticLevels[0]._sockets[i]._Socket;
            _Lc._Tag = "Entry" + (i + 1);

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
            Invoke("SocketController", 2f);
            StartedTime = true;
        }

        if (_TotalSocketCount == 0)
        {
            Win();
        }
    }

    private void PanelOpen(int Index)
    {
        _panels[Index].SetActive(true);
    }

    private void PanelClose(int Index)
    {
        _panels[Index].SetActive(false);
    }

    private void Win()
    {
        PanelOpen(1);
        
        MemoryManagement.SaveDataInt("Level",_SceneIndex+1);
        MemoryManagement.SaveDataInt("Point",MemoryManagement.ReadDataInt("Point")+50);
        _PointText.text = MemoryManagement.ReadDataInt("Point").ToString();
        
        
        Time.timeScale = 0;
    }

    public void Lose()
    {
        Time.timeScale = 0;
        PanelOpen(2);
        
    }

    public void ButtonTehcnical(string process)
    {
        switch (process)
        {
            case "Pause":
                
                PanelOpen(0);
                Time.timeScale = 0;
                break;
            case "continue":
                PanelClose(0);
                Time.timeScale = 1;
                break;
            case "try":
                
                SceneManager.LoadScene(_SceneIndex);
                Time.timeScale = 1;
                break;
            case "nextlevel":
                SceneManager.LoadScene(_SceneIndex+1);
                Time.timeScale = 1;
                break;
            case "exit":
                PanelOpen(3);
                break;
            case "Yes":
                Application.Quit();
                break;
            case "No":
                PanelClose(3);
                break;

            default:
                break;
        }
    }

    void SocketController()
    {
        if (_TotalSocketCount != 0)
        {
            Lose();
        }
    }
}