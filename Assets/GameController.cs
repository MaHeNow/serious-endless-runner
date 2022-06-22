using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.OnHitObstacle += OnPlayerHitObstacle;
        Collectible.OnGotTouched += IncrementPoints;
    }

    void OnPlayerHitObstacle() {
        Globals.score = this.score.score;
        SceneManager.LoadScene(2);
    }

    void IncrementPoints(int by)
    {
        score.score += (float) by;
    }

}
