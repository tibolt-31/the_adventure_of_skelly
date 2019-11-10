using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    public void Open()
    {
        if (isOpen)
            return;
        transform.Rotate(new Vector3(0f, 90f, 0f));
        isOpen = true;
    }

    public void Close()
    {
        if (!isOpen)
            return;
        transform.rotation.Set(0f, 0f, 0f, 0f);
        isOpen = false;
    }
}
