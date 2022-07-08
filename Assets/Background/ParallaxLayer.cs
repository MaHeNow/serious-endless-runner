using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{

    public Camera MainCamera;
    public Transform subject;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2) MainCamera.transform.position - startPosition;
    
    float distanceFromSubject => transform.position.z - subject.position.z;
    
    float parallaxFactor => 3 * Mathf.Abs(distanceFromSubject) / (MainCamera.transform.position.z + MainCamera.farClipPlane);

    void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCamera != null)
        {
            Vector2 newPos = startPosition + travel * parallaxFactor;
            transform.position = new Vector3(newPos.x, newPos.y, startZ);
        }
    }
}
