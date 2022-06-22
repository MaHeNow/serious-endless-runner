using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public delegate void GotTouchedByPlayer();
    public static event GotTouchedByPlayer OnGotTouchedByPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
            OnGotTouchedByPlayer();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") {
            OnGotTouchedByPlayer();
        }
    }
}
