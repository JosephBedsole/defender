using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour {

    public string triggerObject = "Animation1";
    public Animator animator;
	// Use this for initialization
	void OnCollisionEnter(Collision c) {
        animator.SetTrigger(triggerObject);
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider c) {
        animator.SetTrigger(triggerObject);
	}
}
