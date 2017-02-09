using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int lives = 3;
    public int score = 0;

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
    
    public static void LostBall() {
        Debug.Log("Meow... The Cat got the ball.");
        instance.lives = instance.lives - 1;
   }
	
}
