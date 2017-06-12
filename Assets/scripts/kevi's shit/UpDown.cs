using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{

    public GameObject bossbullet;
    public float s = 10f;
    public float up = 3f;
    public float down = -3f;
    bool moveUp = true;
    bool moveDown = true;

    public int dir = 1;

    //Place Animator

    // Use this for initialization
    void Start()
    {

        //Place Animator
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!moveUp)
            {
                dir = -1;
            }
        if (!moveDown)
        {
            dir = 1;
        }
        transform.Translate(0, s * dir * Time.deltaTime, 0);
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
}