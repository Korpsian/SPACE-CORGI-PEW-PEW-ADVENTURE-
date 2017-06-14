﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Leck Mich");
        if (col.name == "BarriereEnd")
        {
            speed = 0;
        }
    }
}
