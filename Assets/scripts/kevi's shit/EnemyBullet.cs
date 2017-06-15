using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 0;
    bool awake = false;
    
    void Start()
    {
       

    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "BarriereRight")
        {
            awake = true;
        }
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (col.name == "BarriereLeft")
        { 
            Destroy(gameObject);
        }
     
    }
}
