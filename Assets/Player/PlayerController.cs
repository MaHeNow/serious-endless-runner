using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 1;
    public float jumpSpeed = 1f;
    public float consecutiveJumpSpeedMultiplier = 1f;


    private Rigidbody2D _rigidbody;
    private float _jumpForce;
    private bool _onGround;
    private bool _inInteractible => _currentInteractable != null;
    private Interactable _currentInteractable;
    [SerializeField] int MaxJumps = 2;
    private int currentJumps = 0;
    private bool justJumped = false;
    [SerializeField] private GameObject groundRay;
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
        groundCheck();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_inInteractible && !_currentInteractable.Used)
            {
                startLoadingInteractable();
            }
            else if (currentJumps < MaxJumps)
            {
                Jump();
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
        }
        else if (other.gameObject.tag == "Interactable")
        {
            _currentInteractable = other.gameObject.GetComponent<Interactable>();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            _currentInteractable = null;
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
        if (currentJumps < MaxJumps)
        {
            if (!justJumped && _onGround)
            {
                justJumped = true;
            }
            jumpSound.Play();
            float jumpMultiplier = currentJumps > 0 ? 0.5f : 1f;
            ForceMode2D mode = currentJumps > 0 ? ForceMode2D.Impulse : ForceMode2D.Impulse;
            _rigidbody.AddForce(new Vector2(0, this._jumpForce * jumpMultiplier), mode);
            currentJumps = currentJumps + 1;
        }
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

    void startLoadingInteractable()
    {
        if (_onGround)
        {
            _currentInteractable.Load();
        }
    }

    void groundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundRay.transform.position, Vector2.down, 0.1f, (1 << LayerMask.NameToLayer("Terrain")));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Ground" && !justJumped)
            {
                _onGround = true;
                currentJumps = 0;
            }
        }
        else
        {
            _onGround = false;
            justJumped = false;
        }
    }

}
