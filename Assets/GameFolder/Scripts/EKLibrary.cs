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

    public static class MemoryManagement
    {
        public static void SaveDataInt(string Key, int Value)
        {
            PlayerPrefs.SetInt(Key,Value);
        }

        public static int ReadDataInt(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }
        public static void SaveDataString(string Key, string Value)
        {
            PlayerPrefs.SetString(Key,Value);
        }

        public static string ReadDataString(string Key)
        {
            return PlayerPrefs.GetString(Key);
        }

        public static bool KeyIsThere(string Key)
        {

            return PlayerPrefs.HasKey(Key);
        }
    }
}
