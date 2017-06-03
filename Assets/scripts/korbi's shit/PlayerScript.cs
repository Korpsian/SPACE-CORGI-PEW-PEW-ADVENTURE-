using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    public GameObject bullet;
    public float horizontalSpeed = 0;
    public float verticalSpeed = 0;
    bool reloaded = true;

    bool moveUp = true;
    bool moveDown = true;
    int movementVertical = 0;

    void FixedUpdate()
    {
        //Bewegung Oben
        if(Input.GetAxis("Vertical") < 0)
        {
            movementVertical = 1;
        } 
        //Unten
        else if(Input.GetAxis("Vertical") > 0)
        {
            movementVertical = -1;
        } else
        {
            movementVertical = 0;
            moveUp = true;
            moveDown = true;
        }

        Movement();
        Shoot(); 
        
    }

    void Movement()
    {

        //Bewegung nach Unten
        if(moveDown)
        {
            if (movementVertical == 1)
            {
                transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
            }
        } 

        //Bewegung nach Oben
        if(moveUp)
        {
            if (movementVertical == -1)
            {
                transform.Translate(Vector3.down * Time.deltaTime * -verticalSpeed);

            }
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

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.name == "BarriereUp")
        {
            Debug.Log("Oben");
            movementVertical = 0;
            moveUp = false;
        }
        
        if(col.name == "BarriereDown")
        {
            movementVertical = 0;
            moveDown = false;
        }
    }

    //Nachladen des Pew Pew
    IEnumerator Reloading(float time)
    {
        reloaded = false;
        yield return new WaitForSeconds(time);
        reloaded = true;
    }

}
