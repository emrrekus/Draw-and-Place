using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example1
{
    public class GenaralManagement
    {
        public static GameManager _GameManager;

        public GenaralManagement(GameManager _gameManager)
        {
            _GameManager = _gameManager;
        }
    }
}
