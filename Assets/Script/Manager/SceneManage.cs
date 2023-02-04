using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneManage : MonoBehaviour
{
    [SerializeField] public static SceneManage Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
}
