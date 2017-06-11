using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed = 0;
    public int damage = 1;

    //Jo lass da wird für Animationen gebraucht boiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
    void Start()
    {
        StartCoroutine(DestroyOverTime());
    }

    //Das Macht das "Pew" in Pew Pew
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    //Jo wenn Trigger Happy dann machsch alles kaputt junge
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BadGuy")
        {
            //Ansonsten kommt noch ein Script auf die Baddies drauf wodurch man eine Methode aufruft
            //Die dann HP abzieht
            other.GetComponent<EnemieLifeManager>().DecreaseLife(damage);
        }

        if (other.tag == "Player")
        {

        }
        else
        {
            Destroy(gameObject);
        }

    }

    IEnumerator DestroyOverTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
