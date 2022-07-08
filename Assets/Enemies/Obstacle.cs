using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject WarningSign;
    public delegate void GotTouchedByPlayer();
    public static event GotTouchedByPlayer OnGotTouchedByPlayer;
    [SerializeField] private AudioSource deathSound; 
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private CapsuleCollider2D capsuleCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

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

    public void Die()
    {
        deathSound.Play();
        spriteRenderer.enabled = false;
        if (boxCollider != null) boxCollider.enabled = false;
        if (capsuleCollider != null) capsuleCollider.enabled = false;
        Destroy(gameObject, deathSound.clip.length);
    }
}
