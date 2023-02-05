using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum E_Character { Pip, ElderLeaf }

[System.Serializable]
public class Dialogue {
    public E_Character Name;
    [TextArea(3, 10)]
    public string Text;
    public Sprite Sprite;
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public static DialogueManager Instance;
    
    public List<Dialogue> DialogueList;
    public PlayableDirector Timeline;
    public GameObject DialogueUI;
    public TextMeshProUGUI TextUI;
    public Image ImageUI;
    public float currentSpeed = 0.15f;
    public float secondsBetweenCharacters = 0.15f;
    public KeyCode dialogueInput = KeyCode.Return;
    public GameObject audioManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown(dialogueInput))
        {
            currentSpeed = 0f;
        }
    }

    public void PlayDialogue()
    {
        DialogueUI.SetActive(true);
        currentSpeed = secondsBetweenCharacters;
        StartCoroutine(LoopDialogue());
    }

    public IEnumerator LoopDialogue()
    {
        foreach (Dialogue dialogue in DialogueList)
        {
            //if (dialogue.Name == E_Character.Pip)
            //{
            //    GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlaySoundEffect(E_SoundEffect.Pip);
            //}
            //if (dialogue.Name == E_Character.ElderLeaf)
            //{
            //    GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlaySoundEffect(E_SoundEffect.Elder_leaf);
            //}
            ImageUI.sprite = dialogue.Sprite;
            bool beforeLast = DialogueList.Count - 2 == DialogueList.IndexOf(dialogue);
            yield return StartCoroutine(DisplayString(dialogue, beforeLast));
            currentSpeed = secondsBetweenCharacters;
            //GameObject.Find("Audio Manager").GetComponent<AudioManager>().StopSoundEffect(E_SoundEffect.Pip);
            //GameObject.Find("Audio Manager").GetComponent<AudioManager>().StopSoundEffect(E_SoundEffect.Elder_leaf);
        }
    }

    public void EndDialogue()
    {
        if (Timeline != null) {
            Timeline.Play();
        }
    }

    private IEnumerator DisplayString(Dialogue dialogue, bool beforeLast)
    {
        int stringLength = dialogue.Text.Length;
        int currentCharacterIndex = 0;
        TextUI.text = "";

        while (currentCharacterIndex < stringLength)
        {

            TextUI.text += dialogue.Text[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength)
            {
                yield return new WaitForSeconds(currentSpeed);
            }
            else
            {
                break;
            }
        }

        while (true)
        {

            if (Input.GetKeyDown(dialogueInput))
            {
                currentSpeed = secondsBetweenCharacters;
                break;
            }

            yield return 0;
        }

        if (beforeLast) {
            EndDialogue();
        }
    }
}
