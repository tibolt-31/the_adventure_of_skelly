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
            FindObjectOfType<DoorManager>().Open(doorName);
            Debug.Log("Collision !! ");
        }
    }
}
