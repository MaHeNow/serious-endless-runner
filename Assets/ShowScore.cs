using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Transform player;
    public float scoreMultiplier = 1;
    public float score = 0;
    Text scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        this.score = player.position.x * scoreMultiplier;
        this.scoreLabel.text = "Score: " + (int)score;
    }
}
