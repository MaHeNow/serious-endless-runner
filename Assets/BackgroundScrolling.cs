using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{  
    public float scrollSpeed;

    private Renderer renderer;
    private Vector2 savedOffset;
    public Transform followTransform;
    public Vector2 cameraOffset = new Vector2(4.0f, 2.0f);

    void Start () {
        renderer = GetComponent<Renderer> ();
    }

    void Update () 
    {
        this.transform.position = new Vector3(followTransform.position.x + cameraOffset.x , cameraOffset.y, this.transform.position.z);    
        
        float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2 (x, 0);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
        
}
