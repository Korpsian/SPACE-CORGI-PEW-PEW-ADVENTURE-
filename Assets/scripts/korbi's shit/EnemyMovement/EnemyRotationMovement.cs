using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotationMovement : MonoBehaviour {

    public bool inverted = false;
    public int speedMin = 5;
    public int speedMax = 10;
    int speed;

	// Use this for initialization
	void Start () {
        speed = Random.Range(speedMin, speedMax);
	}
	
	// Update is called once per frame
	void Update () {
        if (inverted)
        {
        transform.Rotate(Vector3.forward * Time.deltaTime * -speed);
        }
        else
        {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
