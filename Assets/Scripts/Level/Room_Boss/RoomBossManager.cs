using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBossManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyManager.instance.listEnemyCombat.Count == 0)
        {
            Dialog dialog = new Dialog();

            dialog.name = "Team 11";
            dialog.sentences = new string[1];
            dialog.sentences[0] = "Thx you for playing this game, the demo is now over";
            dialog.hasBeenTriggered = false;

            FindObjectOfType<DialogManager>().StartDialogue(dialog);
        }
    }
}
