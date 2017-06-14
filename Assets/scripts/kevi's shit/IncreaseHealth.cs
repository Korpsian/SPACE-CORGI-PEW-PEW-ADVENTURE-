using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            var player = col.gameObject.GetComponent<PlayerScript>();
            player.health = player.health + 1;
            Destroy(gameObject);
        }
    }
}
