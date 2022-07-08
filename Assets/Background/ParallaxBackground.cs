using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public Camera MainCamera;
    public Transform subject;

    void Start()
    {
        if (MainCamera != null)
        {
            ParallaxLayer[] layers = GetComponentsInChildren<ParallaxLayer>();
            foreach (ParallaxLayer layer in layers) {
                layer.MainCamera = this.MainCamera;
                layer.subject = this.subject;
            }
        }
    }
}
