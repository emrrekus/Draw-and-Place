using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EKLibrary
{
    public class General
    {
        public static GameManager _GameManager;

        public General(GameManager _gameManager)
        {

            _GameManager = _gameManager;
        }
    }
    [Serializable]
    public class OtomaticLevel
    {
        public List<EntryObjects> _entryObjects;
        public List<Sockets> _sockets;
        public List<LineRenderer> _lineRenderers;
        



    }
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
}
