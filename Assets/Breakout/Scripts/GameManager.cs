using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text livesText;
    public Text scoreText;
    public Text highScoreText;

    public int lives = 3;
    public int score = 0;
    public int highScore = 0;

    void Awake () {

        if (instance == null) {

            Debug.Log("Yeah!");
            instance = this;
        }
        else {
            // (this.gameObject) and (gameObject) mean the same thing!
            // Destroy is how you "inforce the singlton pattern"
            Debug.Log("oh no"); 
        }

    }
    void Start() {
        livesText.text = "Lives: " + lives;
        scoreText.text = "score: " + score;
        instance.highScoreText.text = "highScore: " + highScore;
    }
    public static void LostBall() {
        Debug.Log("Meow... The Cat got the ball.");
        instance.lives = instance.lives - 1;
        instance.livesText.text = "Lives: " + instance.lives;
   }
    public static void BrickBroken (int points) {
        instance.score += points;
        instance.scoreText.text = "Score: " + instance.score;
        NewHighScore();
   }
    public static void NewHighScore() {

        if (instance.score > instance.highScore) {
            instance.highScore = instance.score;
            instance.highScoreText.text = "highScore " + instance.highScore;

        }

    }
	
}
