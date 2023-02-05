using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Death : MonoBehaviour
{
    public GameObject GameOverUI;

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameOverUI.SetActive(true);
    }
}
