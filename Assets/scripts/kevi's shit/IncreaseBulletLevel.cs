using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletLevel : MonoBehaviour {
    
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            var player = col.gameObject.GetComponent<PlayerScript>();
            player.bulletLvl = player.bulletLvl + 1;
            Destroy(gameObject);
        }
    }
}
