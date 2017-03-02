using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    public int points = 10;
    public GameObject powerupPrefab;
    public float where;
    public int hitCount = 1;

    void OnCollisionExit(Collision c)
    {
        points = points * hitCount;
        hitCount = hitCount - 1;
        Debug.Log("I added a hit counter!");
     
     if (hitCount == 0)
            {
                gameObject.SetActive(false);
                GameManager.BrickBroken(10);
            }
        
    }
}
