using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	
	// Update is called once per frame
	void OnCollisionExit () {
        gameObject.SetActive(false);
	}
}
