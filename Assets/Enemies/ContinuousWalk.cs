using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousWalk : MonoBehaviour
{

    public float movementSpeed = 5;
    void start(){

    }
    void update(){
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
    }

}
