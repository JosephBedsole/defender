﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public static PaddleController instance;

    public float speed = 100;
    public float tilt = 3;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    } 

    void Update() {
        float x = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * speed * x * Time.deltaTime;
        transform.localEulerAngles = Vector3.back * tilt * x;

        Vector3 v = Camera.main.WorldToViewportPoint(transform.position);
        v.x = Mathf.Clamp01(v.x);
        transform.position = Camera.main.ViewportToWorldPoint(v);
    }
}
