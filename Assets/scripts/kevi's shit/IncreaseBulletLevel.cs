using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletLevel : MonoBehaviour {
    
    void OnTriggerEnter2d (Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerScript>().bulletLvl ++;
        }
    }
}
