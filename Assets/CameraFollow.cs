using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    public Vector2 cameraOffset = new Vector2(4.0f, 2.0f);

    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x + cameraOffset.x , cameraOffset.y, this.transform.position.z);
    }
}
