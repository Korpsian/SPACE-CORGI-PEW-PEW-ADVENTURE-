using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour {

    public int hitPoints = 1;
    public int Points = 100;

    public Color hitColor;
	
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
