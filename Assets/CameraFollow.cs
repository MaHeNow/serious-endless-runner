using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    private Vector2 _cameraOffset;

    void Start()
    {
        this._cameraOffset = transform.position;
    }

    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x + this._cameraOffset.x , this._cameraOffset.y, this.transform.position.z);
    }
}
