using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalktableTrigger : MonoBehaviour
{
    private DialogManager dialogueManager;
    
    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogManager>();
    }

    public void Play()
    {
        dialogueManager.OpenNearfOfTalktable();
    }

    public bool IsTrigger()
    {
        return dialogueManager.IsInteractOpen();
    }

    public void Stop()
    {
        dialogueManager.CloseNearOfTalktable();
    }
}
