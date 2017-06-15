using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour {

    public int hitPoints = 1;
    public int Points = 100;
    public bool deathAnimation = false;
    public string deathAnimName;

    public Color hitColor;
    public int randomMax = 10;
    public int randomMin = 1;
    public int grndMax = 10;
    public int grndMin = 1;
    public bool dropchance = false;
    public GameObject item;
    public GameObject health;

    Animation anim;


    private void Start()
    {
        if (deathAnimation)
        {
            anim = gameObject.GetComponent<Animation>();
        }
    }
    // Update is called once per frame
    void Update () {
		if(hitPoints <= 0)
        {
            if (deathAnimation)
            {
                StartCoroutine(DeathAnimation());
            }
            else
            {
                GameObject ScoreManager = GameObject.Find("ScoreManager");
                ScoreManager.GetComponent<ScoreManager>().AddScore(Points);
                if (Random.Range(randomMin, randomMax) <= 2)
                {
                    if (Random.Range(grndMin, grndMax) <= 6)
                    {
                        if (health != null)
                        {
                            Instantiate(health, gameObject.transform.position, Quaternion.identity);
                        }
                    }
                    else
                    {
                        if (item != null)
                        {
                            Instantiate(item, gameObject.transform.position, Quaternion.identity);
                        }
                    }
                }
                Destroy(gameObject);
            }
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
    IEnumerator DeathAnimation()
    {
        GameObject ScoreManager = GameObject.Find("ScoreManager");
        ScoreManager.GetComponent<ScoreManager>().AddScore(Points);
        anim.Play(deathAnimName);

        yield return new WaitForSeconds(2f);

        if (Random.Range(randomMin, randomMax) <= 2)
        {
            if (Random.Range(grndMin, grndMax) <= 6)
            {
                if (health != null)
                {
                    Instantiate(health, gameObject.transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (item != null)
                {
                    Instantiate(item, gameObject.transform.position, Quaternion.identity);
                }
            }
        }
        Destroy(gameObject);

    }
}
