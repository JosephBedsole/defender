﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public static PaddleController instance;
    public string triggerName = "Powerup";

    public AudioSource sound;
    public AudioClip powerUp;
    public AudioClip powerUp2;
    public AudioClip powerUp3;

    public float speed = 100;
    public float tilt = 3;

    Renderer renderer;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
    } 
    void Update() {
        float x = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * speed * x * Time.deltaTime;
        transform.localEulerAngles = Vector3.back * tilt * x;

        ClampToScreen(renderer.bounds.extents.x);
        ClampToScreen(-renderer.bounds.extents.x);
       

    }

    void ClampToScreen (float xOffset) {

        Vector3 v = Camera.main.WorldToViewportPoint(transform.position + Vector3.right * xOffset);
        v.x = Mathf.Clamp01(v.x);
        transform.position = Camera.main.ViewportToWorldPoint(v) - Vector3.right * xOffset;

    }
    void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.tag == "Powerup")
        {
            GameManager.instance.AddLife();
            Debug.Log("1up");

            sound.clip = powerUp;
            sound.Play();

            gameObject.SetActive(false);

        }
        else if (c.gameObject.tag == "Powerup2")
        {
            transform.localScale = new Vector3(2, 1, 1);
            sound.clip = powerUp2;
            sound.Play();
        }
        else
        {
            transform.localScale = new Vector3(.5f, .25f, .25f);

            sound.clip = powerUp3;
            sound.Play();
        }
        //gameObject.SetActive(false);
    }
}
