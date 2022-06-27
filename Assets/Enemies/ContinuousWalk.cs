using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousWalk : MonoBehaviour
{

    public float Speed = 1;


    void FixedUpdate()
    {
        transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
    }

}
