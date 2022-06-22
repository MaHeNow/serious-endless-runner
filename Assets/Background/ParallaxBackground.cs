using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public Camera camera;
    public Transform subject;

    void Start()
    {
        ParallaxLayer[] layers = GetComponentsInChildren<ParallaxLayer>();
        foreach (ParallaxLayer layer in layers) {
            layer.camera = this.camera;
            layer.subject = this.subject;
        }
    }
}
