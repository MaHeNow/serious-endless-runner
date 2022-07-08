using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public ScoreManager ScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        Collectible.OnGotTouchedByPlayer += IncrementCollectibleScore;
        Obstacle.OnGotTouchedByPlayer += EndGame;
        GoalDetection.OnGotTouchedByPlayer += EndGameWin;
    }

    void IncrementCollectibleScore(int by)
    {
        ScoreManager.CollectibleScore += (float) by;
    }

    void EndGame()
    {
        Globals.score = this.ScoreManager.score;
        SceneManager.LoadScene("GameOverScene");
    }

    void EndGameWin()
    {
        Globals.score = this.ScoreManager.score;
        SceneManager.LoadScene("VictoryScene");
    }
}
