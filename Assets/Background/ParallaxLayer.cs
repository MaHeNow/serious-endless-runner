using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{

    public Camera camera;
    public Transform subject;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2) camera.transform.position - startPosition;
    
    float distanceFromSubject => transform.position.z - subject.position.z;
    
    float parallaxFactor => 3 * Mathf.Abs(distanceFromSubject) / (camera.transform.position.z + camera.farClipPlane);

    void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
