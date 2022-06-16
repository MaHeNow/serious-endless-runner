using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public Transform player;
    public float scoreMultiplier = 1;
    public float score;

    // Update is called once per frame
    void Update()
    {
        this.score = player.position.x * scoreMultiplier;
    }

    public float GetScore() => score;
}
