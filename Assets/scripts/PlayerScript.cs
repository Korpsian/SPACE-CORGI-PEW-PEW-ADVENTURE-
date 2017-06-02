﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject bullet;
    public float horizontalSpeed = 0;
    public float verticalSpeed = 0;
    bool reloaded = true;

    void FixedUpdate()
    {
        Movement();
        Shoot();
    }

    void Movement()
    {
        if(Input.GetAxis("Vertical") < 0 )
        {
            transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * -verticalSpeed);
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);

        }

    }
    void Shoot()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (reloaded)
            {
                //Jo man soll nicht wie ein affe schießen dürfen
                StartCoroutine(Reloading(0.2f));

                //Finde den Standpunkt des Corgis heraus und speichere ihn
                Vector2 thisOne = this.transform.position;
                //Füge einen abstand hinzu
                thisOne.x = thisOne.x + 1;
                //Erstelle an dieser Position einen Pew Pew
                Instantiate(bullet, thisOne, Quaternion.identity);

            }

        }
    }

    //Reloading the Pew Pew
    IEnumerator Reloading(float time)
    {
        reloaded = false;
        yield return new WaitForSeconds(time);
        reloaded = true;
    }

}
