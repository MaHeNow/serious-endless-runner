using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    
    public int points = 40;
    public delegate void GotTouchedByPlayer(int score);
    public static event GotTouchedByPlayer OnGotTouchedByPlayer;

    [SerializeField] private AudioSource collectSound1;
    [SerializeField] private AudioSource collectSound2;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            OnGotTouchedByPlayer(points);
            PlayCollectSound();
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
            Destroy(gameObject, collectSound1.clip.length);
        }
    }
        
    void PlayCollectSound()
    {
        AudioSource[] collectSounds = new [] {collectSound1, collectSound2};
        AudioSource collectSound = collectSounds[Random.Range(minInclusive: 0, collectSounds.Length)];
        collectSound.Play();
    }

}
