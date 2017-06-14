using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{

    bool moveUp = true;
    bool moveDown = true;
    public float s = 10f;
    bool awake = false;

    int dir = 1;

    //Place Animator

    // Use this for initialization
    void Start()
    {

        //Place Animator
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (awake == true)
        {
            if (!moveUp)
            {
                dir = -1;
                moveUp = true;
            }
            if (!moveDown)
            {
                dir = 1;
                moveDown = true;
            }
            transform.Translate(0, s * dir * Time.deltaTime, 0);
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.name == "BarriereUp")
        {
            //Debug.Log("Oben");
            moveUp = false;
        }

        if (col.name == "BarriereDown")
        {
           moveDown = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "BarriereRight")
        {
            awake = true;
        }
    }
}