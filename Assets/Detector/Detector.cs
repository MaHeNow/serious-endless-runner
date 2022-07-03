using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public string TagToDetect;
    public delegate void Detected();
    public event Detected OnDetected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagToDetect)
        {
            OnDetected();
        }
    }
}
