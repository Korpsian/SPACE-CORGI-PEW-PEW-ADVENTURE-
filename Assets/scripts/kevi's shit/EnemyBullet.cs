using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 0;
    
    void Start()
    {
        StartCoroutine(DestroyOverTime());
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    IEnumerator DestroyOverTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
