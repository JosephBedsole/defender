﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public BrickController brickPrefab;
    public int rows = 5;
    public int columns = 10;
    public float edgePadding = 0.1f;
    public float bottomPadding = 0.4f;
    
    List<BrickController> brickList = new List<BrickController>();


    public Text livesText;
    public Text scoreText;
    public Text highScoreText;
    public Text gameOverText;
    public Text winText;

    public int lives = 3;
    public int score = 0;
    public int highScore = 0;

    public int brickCount;

    private GameObject[] getCount;

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
        CreateBricks();
        BrickCount();
    }
    void CreateBricks() {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(edgePadding, bottomPadding, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1 - edgePadding, 1 - edgePadding, 0));
        bottomLeft.z = 0;
        float w = (topRight.x - bottomLeft.x) / (float)columns;
        float h = (topRight.y - bottomLeft.y) / (float) rows;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                BrickController brick = Instantiate(brickPrefab) as BrickController;
                brick.transform.position = bottomLeft + new Vector3((col + 0.5f) * w, (row + 0.5f)* h, 0);
                brickList.Add(brick);
            }
        }
        

    }

    public static void LostBall() {
        Debug.Log("Meow... The Cat got the ball.");
        instance.lives = instance.lives - 1;
        if (instance.lives < 0)
        {
            instance.gameOverText.text = "You Lose";
            instance.gameOverText.gameObject.SetActive(true);
        }
        else {
            instance.livesText.text = "Lives: " + instance.lives;
        }
   }
    public static void BrickBroken (int points) {
        instance.score += points;
        instance.scoreText.text = "Score: " + instance.score;
        NewHighScore();
        BrickCount();

        bool hasWon = true;
        for (int i = 0; i < instance.brickList.Count; i++) {
            BrickController brick = instance.brickList[i];
            if (brick.gameObject.activeSelf) {
                hasWon = false;
                break;
            }
        }

        if (hasWon) {
            instance.winText.text = "You Win!";
            instance.winText.gameObject.SetActive(true);
        }
    }
    public static void NewHighScore() {

        if (instance.score > instance.highScore) {
            instance.highScore = instance.score;
            instance.highScoreText.text = "highScore " + instance.highScore;

        }

    }
    public static void BrickCount () {
        instance.getCount = GameObject.FindGameObjectsWithTag("Bricks");
        instance.brickCount = instance.getCount.Length;
    }
}
