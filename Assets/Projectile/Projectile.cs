using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float Speed = 3;
    public float LifeTime = 2;


    void FixedUpdate()
    {
        transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        LifeTime -= Time.deltaTime;
        if (LifeTime < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            other.gameObject.GetComponent<Obstacle>().Die();
            Destroy(this.gameObject);
        }
    }

}
