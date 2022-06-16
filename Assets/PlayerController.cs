using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    public float MovementSpeed = 5;

    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this._rigidbody.velocity = new Vector2(MovementSpeed, 0);
    }
}
