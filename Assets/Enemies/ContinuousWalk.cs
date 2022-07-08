using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousWalk : Walk
{

    public float Speed = 1;


    void FixedUpdate()
    {
        if (moving)
        {
            transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
        }
    }

}
