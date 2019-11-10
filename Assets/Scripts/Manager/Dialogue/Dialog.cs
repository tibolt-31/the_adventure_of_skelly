﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog 
{
    public string name;
    public bool hasBeenTriggered = false;
    [TextArea(1, 2)]
    public string[] sentences;
    public EventDialogueFinished eventDialogueFinished;
}
