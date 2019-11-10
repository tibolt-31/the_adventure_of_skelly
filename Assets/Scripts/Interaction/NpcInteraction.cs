using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void EventDialogueFinished();

public class NpcInteraction : MonoBehaviour
{
    private DialogTrigger dialogueTrigger;
    private TalktableTrigger talktableTrigger;
    private EventDialogueFinished OnDialogueFinished;
    
    public bool isOpenDoor;
    public string roomName;

    private void Start()
    {
        isOpenDoor = false;
        dialogueTrigger = GetComponent<DialogTrigger>();
        talktableTrigger = GetComponent<TalktableTrigger>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(PlayerManager.instance.Player.transform.position, transform.position) <= 2)
        {

            talktableTrigger.Play();
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnDialogueFinished += CallbackOpenDoor;
                dialogueTrigger.TriggerDialog(OnDialogueFinished);
            }
        }
        else
        {
            if (talktableTrigger.IsTrigger())
                talktableTrigger.Stop();
        }
    }

    public void CallbackOpenDoor()
    {
        if (!isOpenDoor && dialogueTrigger.dialogue.hasBeenTriggered)
        {
            FindObjectOfType<DoorManager>().Open(roomName);
            isOpenDoor = true;
        }
    }
}
