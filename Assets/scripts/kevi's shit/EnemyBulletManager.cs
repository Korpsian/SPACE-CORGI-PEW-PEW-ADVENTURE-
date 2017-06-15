using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour {

    public GameObject EnemyBullet;
    // Use this for initialization
    public void InstantiateBullet()
    {
        Vector2 pos;
        //pos = this.transform.GetChild(0).transform.position;
        pos = this.transform.position;
        Instantiate(EnemyBullet, pos, Quaternion.identity);
    }
}
