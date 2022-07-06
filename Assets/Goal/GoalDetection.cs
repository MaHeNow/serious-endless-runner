using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GoalDetection : MonoBehaviour
{
    public delegate void GotTouchedByPlayer();
    public static event GotTouchedByPlayer OnGotTouchedByPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnGotTouchedByPlayer();
        }
    }

}
