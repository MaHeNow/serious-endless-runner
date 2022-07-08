using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float movementSpeed = 5;
    public float jumpSpeed = 35f;


    private Rigidbody2D _rigidbody;
    private float _jumpForce;
    private bool _onGround;
    private bool _inInteractible => _currentInteractable != null;
    private Interactable _currentInteractable;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource landSound;
    [SerializeField] private AudioSource stepSound1;
    [SerializeField] private AudioSource stepSound2;


    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._jumpForce = Mathf.Sqrt(jumpSpeed * -3 * (Physics2D.gravity.y * _rigidbody.gravityScale)); 
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_onGround)
            {
                if (_inInteractible && !_currentInteractable.Used)
                {
                    _currentInteractable.Load();
                }
                else
                {
                    Jump();
                }
            } 
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_inInteractible)
            {
                _currentInteractable.Trigger();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        { 
            landSound.Play();
            _onGround = true;
        }
        else if (other.gameObject.tag == "Interactable")
        {
            _currentInteractable = other.gameObject.GetComponent<Interactable>();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _onGround = false;
        }
        else if (other.gameObject.tag == "Interactable")
        {
            _currentInteractable = null;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        { 
            _onGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            _currentInteractable = other.gameObject.GetComponent<Interactable>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            _currentInteractable = null;
        }
    }

    void Jump()
    {
        jumpSound.Play();
        _rigidbody.AddForce(new Vector2(0, this._jumpForce), ForceMode2D.Impulse);
    }

    void makeStepSound()
    {
        if (_onGround)
        {
            AudioSource[] stepSounds = new [] {stepSound1, stepSound2};
            AudioSource stepSound = stepSounds[Random.Range(0, stepSounds.Length)];
            stepSound.Play();
        }
    }

}
