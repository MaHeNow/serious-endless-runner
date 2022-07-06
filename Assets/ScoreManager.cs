using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public float RunningScore;
    public float CollectibleScore;

    public Transform player;
    public float scoreMultiplier = 1;
    public float score
    {
        get => RunningScore + CollectibleScore;
    }
    

    // Update is called once per frame
    void Update()
    {
        this.RunningScore = player.position.x * scoreMultiplier;
    }

}
