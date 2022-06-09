using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D Transform;
    public float MovementSpeed = 5;

    void Start()
    {
        Transform = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Transform.velocity = new Vector2(MovementSpeed, 0);
    }
}
