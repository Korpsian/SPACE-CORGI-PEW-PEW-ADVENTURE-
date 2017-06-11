using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10;
    public float delay = 1;
    public int movement = 0;

    public bool awake = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(ZigZag(delay));
	}
	
	// Update is called once per frame
	void Update () {
        if(movement == 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (movement == 1)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

    }

    IEnumerator ZigZag(float delay)
    {
        movement = 1;
        yield return new WaitForSeconds(delay);
        movement = 0;
        StartCoroutine(ZigZag(delay));
    }

}
