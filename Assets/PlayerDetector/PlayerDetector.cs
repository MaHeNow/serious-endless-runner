using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public delegate void DetectedPlayer();
    public event DetectedPlayer OnDetectedPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnDetectedPlayer();
        }
    }
}
