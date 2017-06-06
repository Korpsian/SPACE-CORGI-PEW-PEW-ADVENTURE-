using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public GameObject Score;
    int score = 0;
    int points = 0;

    private void Start()
    {
        StartCoroutine(UpdScoreVisual(0f));
        AddScore(1000);
    }

    //Das sind die extra punkte die dazu kommen sollen, können auch negativ sein fürs abziehen
    public void AddScore(int newPoints)
    {
        points = points + newPoints;
    }

    private void Update()
    {
        UpdScorePositive();
        UpdScoreNegative();

    }

    void UpdScorePositive()
    {
        if (points <= 9999999 && points >= 100000)
        {
            StartCoroutine(UpdScoreVisual(0.1f));
            points = points - 10000;
            score = score + 10000;
        }
        if (points <= 100000 && points >= 10000)
        {
            StartCoroutine(UpdScoreVisual(0.1f));
            points = points - 1000;
            score = score + 1000;
        }
        if (points <= 10000 && points >= 1000)
        {
            StartCoroutine(UpdScoreVisual(0.1f));
            points = points - 100;
            score = score + 100;
        }
        if (points <= 1000 && points >= 100)
        {
            StartCoroutine(UpdScoreVisual(0.1f));
            points = points - 10;
            score = score + 10;
        }
        if (points <= 100 && points > 0)
        {
            StartCoroutine(UpdScoreVisual(0.1f));
            points = points - 1;
            score = score + 1;
        }

    }

    void UpdScoreNegative()
    {
        if(points >= -1000 && points <= -100)
        {
            points = points + 10;
            score = score - points;
            StartCoroutine(UpdScoreVisual(0.1f));
        }
        if (points < 0 && points >= -100)
        {
            points++;
            score--;
            StartCoroutine(UpdScoreVisual(0.1f));
        }
    }

    IEnumerator UpdScoreVisual(float time)
    {
        yield return new WaitForSeconds(time);
        Text temp = Score.GetComponent<Text>();
        temp.text = "Score: " + score;
        Debug.Log("I Updated Score");

    }

}
