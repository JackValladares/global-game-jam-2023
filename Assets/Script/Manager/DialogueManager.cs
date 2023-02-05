using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum E_Character { Pip, ElderLeaf }

[System.Serializable]
public class Dialogue {
    public E_Character Name;
    [TextArea(3, 10)]
    public string Text;
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public static DialogueManager Instance;
    
    public List<Dialogue> DialogueList;
    public PlayableDirector Timeline;
    public GameObject DialogueUI;
    public TextMeshProUGUI TextUI;
    public float currentSpeed = 0.15f;
    public float secondsBetweenCharacters = 0.15f;
    public KeyCode dialogueInput = KeyCode.Return;
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
        currentSpeed = secondsBetweenCharacters;
        DialogueUI.SetActive(true);
        StartCoroutine(LoopDialogue());
    }

    public IEnumerator LoopDialogue()
    {
        foreach (Dialogue dialogue in DialogueList)
        {
            bool isLast = DialogueList.Count - 1 == DialogueList.IndexOf(dialogue);
            yield return StartCoroutine(DisplayString(dialogue, isLast));
            currentSpeed = secondsBetweenCharacters;
        }
    }

    public void EndDialogue()
    {
        GameObject.FindWithTag("DialogueUI").SetActive(false);

        if (Timeline != null) {
            Timeline.Play();
        }
    }

    private IEnumerator DisplayString(Dialogue dialogue, bool isLast)
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

        if (isLast) {
            EndDialogue();
        }
    }
}
