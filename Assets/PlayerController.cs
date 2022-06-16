using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5;
    public float jumpSpeed = 35f;

    private Rigidbody2D _rigidbody;
    private float _jumpForce;

    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._jumpForce = Mathf.Sqrt(jumpSpeed * -2 * (Physics2D.gravity.y * _rigidbody.gravityScale)); 
    }

    void FixedUpdate() {
        transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            this._rigidbody.AddForce(new Vector2(0, this._jumpForce), ForceMode2D.Impulse);
        } 
    }
}
