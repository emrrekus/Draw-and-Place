using System;
using System.Collections;
using System.Collections.Generic;
using EKLibrary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _LoadingPanel;
    private void Awake()
    {
        if (!MemoryManagement.KeyIsThere("Level"))
        {
            MemoryManagement.SaveDataInt("Level",1);
            MemoryManagement.SaveDataInt("Point",50);
            MemoryManagement.SaveDataInt("GameSound",1);
            MemoryManagement.SaveDataInt("EffectSound",1);
        }
    }

    public void Begin()
    {
        StartCoroutine(SceneLoadign(MemoryManagement.ReadDataInt("Level")));
    }

    IEnumerator SceneLoadign(int SceneIndex)
    {
        AsyncOperation Op = SceneManager.LoadSceneAsync(SceneIndex);
        _LoadingPanel.SetActive(true);
        while (!Op.isDone)
        {
            float prog = Mathf.Clamp01(Op.progress / .9f);
            _slider.value = prog;
            yield return null;

        }
    }
}
