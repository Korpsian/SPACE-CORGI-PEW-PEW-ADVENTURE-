﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "BarriereEnd") ;
        speed = 0;
    }
}
