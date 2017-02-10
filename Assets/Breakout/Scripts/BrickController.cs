using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    public int points = 10;

	// Update is called once per frame
	void OnCollisionExit () {
        gameObject.SetActive(false);
        GameManager.BrickBroken(10);
	}
}
