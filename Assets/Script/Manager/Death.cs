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
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
            GameOverUI.SetActive(true);
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().ChangeBackground(E_BackGroundMusic.Game_Over);
        }

    }
}
