using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    public int points = 10;
    public GameObject powerupPrefab;
    public float where;

    void OnCollisionExit()
    {
        gameObject.SetActive(false);
        GameManager.BrickBroken(10);
    }
}
