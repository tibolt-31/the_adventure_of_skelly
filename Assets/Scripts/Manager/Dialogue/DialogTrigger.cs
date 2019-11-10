using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialogue;
    public delegate void Event(); // declare delegate type
    public void TriggerDialog(EventDialogueFinished onDialogFinished = null)
    {
        var dialogueManager = FindObjectOfType<DialogManager>();
        dialogue.eventDialogueFinished = onDialogFinished;
        if (!dialogueManager.isDialoguePlayed)
        {
            FindObjectOfType<DialogManager>().StartDialogue(dialogue);
        }
    }
}
