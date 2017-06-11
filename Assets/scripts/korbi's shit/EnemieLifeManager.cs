using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieLifeManager : MonoBehaviour {

    public int hitPoints = 1;
    public int Points = 100;

	
	// Update is called once per frame
	void Update () {
		if(hitPoints <= 0)
        {
            GameObject ScoreManager = GameObject.Find("ScoreManager");
            ScoreManager.GetComponent<ScoreManager>().AddScore(Points);
            Destroy(gameObject);
        }
	}

    public void DecreaseLife(int amount)
    {
        hitPoints = hitPoints - amount;
    }
}
