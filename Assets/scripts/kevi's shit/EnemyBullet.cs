using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 0;
    bool awake = false;
    
    void Start()
    {
        StartCoroutine(DestroyOverTime());
    }

    void Update()
    {
       
            transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (col.name == "BarriereLeft")
        { 
            Destroy(gameObject);
        }
    }
    IEnumerator DestroyOverTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
