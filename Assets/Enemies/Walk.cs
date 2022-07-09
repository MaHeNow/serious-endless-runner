using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public bool MoveAutomatically = false;
    protected bool moving = false;

    void Start()
    {
        if (MoveAutomatically)
        {
            Move();
        }
    }

    public void Move()
    {
        moving = true;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "WarningSignSpawner")
        {
            Move();
        }
    }

}
