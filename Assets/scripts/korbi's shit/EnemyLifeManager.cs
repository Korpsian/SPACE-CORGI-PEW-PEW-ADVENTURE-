﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour {

    public int hitPoints = 1;
    public int Points = 100;

    public Color hitColor;
    public int randomMax = 10;
    public int randomMin = 1;
    public int grndMax = 10;
    public int grndMin = 1;
    public bool dropchance = false;
    public GameObject item;
    public GameObject health;

	// Update is called once per frame
	void Update () {
		if(hitPoints <= 0)
        {
            GameObject ScoreManager = GameObject.Find("ScoreManager");
            ScoreManager.GetComponent<ScoreManager>().AddScore(Points);
            if (Random.Range(randomMin, randomMax) <= 2)
            {
                if (Random.Range(grndMin, grndMax) <= 6)
                {
                    Instantiate(health, gameObject.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(item, gameObject.transform.position, Quaternion.identity);
                }
            }

            Destroy(gameObject);
        }
	}

    public void DecreaseLife(int amount)
    {
        hitPoints = hitPoints - amount;
        StartCoroutine(GetHit());
    }

    IEnumerator GetHit()
    {
        Color temp = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = hitColor;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = temp;

    }
}
