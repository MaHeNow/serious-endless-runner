using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        Collectible.OnGotTouchedByPlayer += IncrementPoints;
        Obstacle.OnGotTouchedByPlayer += EndGame;
    }

    void IncrementPoints(int by)
    {
        score.score += (float) by;
    }

    void EndGame()
    {
        Globals.score = this.score.score;
        SceneManager.LoadScene(2);
    }

}
