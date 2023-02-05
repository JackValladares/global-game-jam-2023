using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneManage : MonoBehaviour
{
    public void LoadScene(string scene) 
    {
        Debug.Log(scene);
        SceneManager.LoadScene(scene);
    }
}
