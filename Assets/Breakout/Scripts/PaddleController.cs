using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {


    public float speed = 100;

    void Update() {
        float x = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * speed * x * Time.deltaTime;
    }
}
