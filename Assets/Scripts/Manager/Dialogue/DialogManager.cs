using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator anim;
    public bool isDialoguePlayed;

    public Animator animInteract;

    private Coroutine typeSequenceCor;

    private Queue<string> sentences;
    private EventDialogueFinished tempEvent;

    private void Start()
    {
        isDialoguePlayed = false;
        sentences = new Queue<string>();
        tempEvent = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isDialoguePlayed)
        {
            StopCoroutine(typeSequenceCor);
            DisplayNextScene();
        }
    }

    public void OpenNearfOfTalktable()
    {
        if (IsInteractOpen() || isDialoguePlayed)
            return;
        animInteract.SetBool("IsOpen", true);
    }

    public void CloseNearOfTalktable()
    {
        animInteract.SetBool("IsOpen", false);
    }

    public bool IsInteractOpen()
    {
        return animInteract.GetBool("IsOpen");
    }

    public void StartDialogue(Dialog dialogue)
    {
        if (IsInteractOpen())
            CloseNearOfTalktable();

        anim.SetBool("IsOpen", true);
        isDialoguePlayed = true;
        sentences.Clear();
        nameText.text = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        tempEvent += dialogue.eventDialogueFinished;
        dialogue.hasBeenTriggered = true;
        DisplayNextScene();
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void DisplayNextScene()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        typeSequenceCor = StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    public void EndDialogue()
    {
        isDialoguePlayed = false;
        anim.SetBool("IsOpen", false);
        tempEvent?.Invoke();
        tempEvent = null;
    }
}
