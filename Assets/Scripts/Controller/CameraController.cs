using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetTransform;
    public float yOffset;
    public float zOffset;
    Vector3 tempVec3 = new Vector3();

    void LateUpdate()
    {
        tempVec3.x = targetTransform.position.x;
        tempVec3.y = targetTransform.position.y + yOffset;
        tempVec3.z = targetTransform.position.z - zOffset;
        this.transform.position = tempVec3;
        this.transform.rotation = Quaternion.Euler(50, 0, 0);
    }
}
