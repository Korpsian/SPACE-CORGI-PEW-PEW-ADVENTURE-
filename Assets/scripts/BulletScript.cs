using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed = 0; 

    void Start()
    {
        Debug.Log("I am alive");
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll);
        Debug.Log("Hit");
    }
}
