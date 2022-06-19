using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5;
    public float jumpSpeed = 35f;

    public delegate void HitObstacle();
    public static event HitObstacle OnHitObstacle;

    private Rigidbody2D _rigidbody;
    private float _jumpForce;
    private bool _onGround;

    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._jumpForce = Mathf.Sqrt(jumpSpeed * -2 * (Physics2D.gravity.y * _rigidbody.gravityScale)); 
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this._onGround) {
            this._rigidbody.AddForce(new Vector2(0, this._jumpForce), ForceMode2D.Impulse);
        } 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") { 
            this._onGround = true;
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
