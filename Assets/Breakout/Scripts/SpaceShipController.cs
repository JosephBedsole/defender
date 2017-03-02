using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

    public int speed = 10;

	void Update () {
        float x = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * speed * x * Time.deltaTime;
        float y = Input.GetAxis("Vertical");
        transform.position += Vector3.up * speed * y * Time.deltaTime;
    }
}
