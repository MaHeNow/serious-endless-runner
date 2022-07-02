using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5;
    public float jumpSpeed = 35f;
    public AudioSource jumpsound;
    public delegate void HitObstacle();
    public static event HitObstacle OnHitObstacle;
    public int counter;
    private Rigidbody2D _rigidbody;
    private float _jumpForce;
    private bool _onGround;

    private int NumberJumps ;
    private int MaxJumps = 2;

    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._jumpForce = 3.5f;
        jumpsound = GetComponent<AudioSource>();
        NumberJumps = 0;
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
    }
    
    
    void Update()
    {   

       
         if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (this._onGround || (NumberJumps > 0 && NumberJumps < MaxJumps)) {
                this._rigidbody.AddForce(new Vector2(0, this._jumpForce), ForceMode2D.Impulse);
                jumpsound.Play();
                NumberJumps = NumberJumps +  1;
            }
           
        }


        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") { 
            this._onGround = true;
            NumberJumps = 0;
        } else if (other.gameObject.tag == "Obstacle") {
            OnHitObstacle();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") { 
            this._onGround = false;
        } else if (other.gameObject.tag == "Obstacle") {
            Debug.Log("HitOUT");
           // BackgroundScrolling.scrollSpeed = 0.1f; 
        }
    }
}



