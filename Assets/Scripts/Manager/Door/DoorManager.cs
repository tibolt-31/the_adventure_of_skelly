using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<Door> listDoor = new List<Door>();

    public void Open(string name)
    {
        listDoor.Find(door => door.name.Contains(name)).Open();
    }

    public void Close(string name)
    {
        listDoor.Find(door => door.name.Contains(name)).Close();
    }
}
