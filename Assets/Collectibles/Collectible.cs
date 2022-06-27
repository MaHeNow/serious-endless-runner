using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    
    public int points = 40;
    public delegate void GotTouchedByPlayer(int score);
    public static event GotTouchedByPlayer OnGotTouchedByPlayer;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            OnGotTouchedByPlayer(points);
            Destroy(gameObject);
            
        }
    }
        
}
