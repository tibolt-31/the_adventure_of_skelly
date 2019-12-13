using System.Collections.Generic;
using UnityEngine;

public class StartRoomManager : MonoBehaviour
{
    public static bool isEnemyDown = false;
    public static bool isBossDoorOpen = false;
    private bool enemiesDeleted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isEnemyDown)
        {
            FindObjectOfType<DoorManager>().Open("Startroom_Door");
            FindObjectOfType<DoorManager>().Open("Left_Door");
            FindObjectOfType<DoorManager>().Open("Right_Door");
            Debug.Log(GameManager.currentRoomName);
            if (GameManager.currentRoomName == "Room_1")
                PlayerManager.instance.Player.transform.position = new Vector3(-1.58f, 0f, 41.3f);
            else if (GameManager.currentRoomName == "Room_5")
                PlayerManager.instance.Player.transform.position = new Vector3(2.37f, 0f, 41.6f);
        }
        GameManager.currentRoomName = "StartRoom";
        if (GameManager.levelClear)
        {
            FindObjectOfType<DoorManager>().Open("Boss_Door");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyManager.instance.listEnemyCombat.Count == 0 && !isEnemyDown)
        {
            isEnemyDown = true;
            OpenDoors();
        }

        if (!enemiesDeleted && isEnemyDown)
        {
            EnemyManager.instance.listEnemyCombat.ForEach(enemy => { Destroy(enemy.gameObject); });
            enemiesDeleted = true;
        }

        void OpenDoors()
        {
            FindObjectOfType<DoorManager>().Open("Left_Door");
            FindObjectOfType<DoorManager>().Open("Right_Door");
        }
    }
}
