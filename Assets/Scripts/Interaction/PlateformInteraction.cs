using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformInteraction : MonoBehaviour
{
    public GameObject boxRef;
    public string doorName;
    private Vector3 pos;

    private bool isBlock = false;

    // Update is called once per frame
    void Update()
    {
        if (isBlock)
            boxRef.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pushable" && !isBlock)
        {
            pos = boxRef.transform.position;
            isBlock = true;

            
            if (doorName == "Door_Boss" && !GameManager.levelClear)
            {
                GameManager.levelClear = true;
                Dialog dialog = new Dialog();

                dialog.name = "A Png";
                dialog.sentences = new string[1];
                dialog.sentences[0] = "The boss door have been opened ! Go back to the previous room";
                dialog.hasBeenTriggered = false;

                FindObjectOfType<DialogManager>().StartDialogue(dialog);
            }
            else
            {
                FindObjectOfType<DoorManager>().Open(doorName);
            }
        }
    }
}
