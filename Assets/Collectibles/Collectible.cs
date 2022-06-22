using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    
    public int points = 40;
    public delegate void GotTouched(int score);
    public static event GotTouched OnGotTouched;

    private BoxCollider2D _bc;

    // Start is called before the first frame update
    void Start()
    {
        this._bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            OnGotTouched(points);
            Destroy(gameObject);
        }
    }
        
}
