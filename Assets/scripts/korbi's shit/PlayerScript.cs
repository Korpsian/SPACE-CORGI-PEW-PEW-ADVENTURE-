using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    public GameObject bullet;
    public float horizontalSpeed = 0;
    public float verticalSpeed = 0;
    public float shootSpeed = 0;
    bool reloaded = true;

    bool moveUp = true;
    bool moveDown = true;
    bool moveRight = true;
    bool moveLeft = true;

    int movementVertical = 0;
    int movementHorizontal = 0;

    public Animator bulletAnim;
    private void Start()
    {
        bulletAnim = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Bewegung Unten
        if(Input.GetAxisRaw("Vertical") < 0)
        {
            movementVertical = 1;
        } 
        //Oben
        else if(Input.GetAxisRaw("Vertical") > 0)
        {
            movementVertical = -1;
        } else
        {
            movementVertical = 0;
            moveUp = true;
            moveDown = true;
        }

        //Rechts
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            Debug.Log("Rechts");
            movementHorizontal = 1;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            Debug.Log("Links");
            movementHorizontal = -1;
        }
        else
        {
            movementHorizontal = 0;
            moveRight = true;
            moveLeft = true;
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

        //Bewegung nach Rechts
        if (moveRight)
        {
            if(movementHorizontal == 1)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed / 2f);
            }
        }

        //Bewegung nach Links
        if (moveLeft)
        {
            if (movementHorizontal == -1)
            {
                transform.Translate(Vector3.right * Time.deltaTime * -horizontalSpeed);
            }
        }

    }

    void Shoot()
    {
        if (Input.GetButton("Jump"))
        {
            if (reloaded)
            {
                //Jo man soll nicht wie ein affe schießen dürfen
                StartCoroutine(Reloading(shootSpeed));

                //Finde den Standpunkt des Corgis heraus und speichere ihn
                Vector2 thisOne = this.transform.position;
                //Füge einen abstand hinzu
                thisOne.x = thisOne.x + 2;

                bulletAnim.Play("create_beam");
                //Erstelle an dieser Position einen Pew Pew
                Instantiate(bullet, thisOne, Quaternion.identity);
            } 
        }
        else
        {
            bulletAnim.Play("Start");
        }
    }

    void OnTriggerStay2D(Collider2D col)
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

        if(col.name == "BarriereRight")
        {
            movementHorizontal = 0;
            moveRight = false;
        }

        if (col.name == "BarriereLeft")
        {
            movementHorizontal = 0;
            moveLeft = false;
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
