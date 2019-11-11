using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Manager : MonoBehaviour
{
    public GameObject box1;
    public GameObject box2;

    public static bool isTopDoorOpen = false;
    public static bool isEnemyDown = false;
    public static bool isFirstTimeInRoom = true;

    private  bool enemiesDeleted = false;
    private static Vector3 box1LastPos;
    private static Vector3 box2LastPos;

    
    void Start()
    {
        
        if (isEnemyDown)
        {
            FindObjectOfType<DoorManager>().Open("Door_1_Right");
            FindObjectOfType<DoorManager>().Open("Door_1_Top");
        }
        
        if (GameManager.currentRoomName == "StartRoom")
        {
            PlayerManager.instance.Player.transform.position = new Vector3(3.16f, 0.012f, 36.32f);
        }
        else
        {
            PlayerManager.instance.Player.transform.position = new Vector3(4.14f, 0.12f, 41.56f);
        }
        if (isFirstTimeInRoom)
        {
            isFirstTimeInRoom = false;
        }
        else
        {
            box1.transform.position = box1LastPos;
            box2.transform.position = box2LastPos;
        }
        
        GameManager.currentRoomName = "Room_1";
       
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyManager.instance.listEnemyCombat.Count == 0 && !isEnemyDown)
        {
            isEnemyDown = true;
        }

        if (!enemiesDeleted && isEnemyDown)
        {
            EnemyManager.instance.listEnemyCombat.ForEach(enemy => { Destroy(enemy.gameObject); });
            enemiesDeleted = true;
        }
        box1LastPos = box1.transform.position;
        box2LastPos = box2.transform.position;
    }

    void OpenDoors()
    {
        FindObjectOfType<DoorManager>().Open("Door_Right");
    }
}
