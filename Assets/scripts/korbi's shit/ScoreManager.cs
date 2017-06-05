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
        StartCoroutine(UpdScoreOverTime(0f));
    }

    //Das sind die extra punkte die dazu kommen sollen, können auch negativ sein fürs abziehen
    public void UpdScore(int newPoints)
    {
        points = points + newPoints;
    }

    private void Update()
    {
        if(points > 0)
        {
            points--;
            score++;
            StartCoroutine(UpdScoreOverTime(0.5f));
        }

        if(points < 0)
        {
            points++;
            score--;
            StartCoroutine(UpdScoreOverTime(0.5f));
        }
    }

    IEnumerator UpdScoreOverTime(float time)
    {
        yield return new WaitForSeconds(time);
        Text temp = Score.GetComponent<Text>();
        temp.text = "Score: " + score;
        Debug.Log("I Updated Score");

    }

}
