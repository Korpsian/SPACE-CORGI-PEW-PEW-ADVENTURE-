using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    
    //Bullet die Verschossen wird
    public float horizontalSpeed = 0;
    public float verticalSpeed = 0;
    public float shootSpeed = 0;

    public int lifes = 3;
    public int health = 5;
    public int bulletLvl = 1;

    bool reloaded = true;
    bool moveUp = true;
    bool moveDown = true;
    bool moveRight = true;
    bool moveLeft = true;
    public bool allowMoving = true;

    int movementVertical = 0;
    int movementHorizontal = 0;

    Animator bulletAnim;
    Animator playerAnim;
    AudioSource audio;
    public AudioClip pew;

    private void Start()
    {
        bulletAnim = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        playerAnim = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Movement();
        Shoot();
        MaxHealth();
    }

    void Movement()
    {
        if (allowMoving)
        {
            //Bewegung Unten
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                movementVertical = 1;
            }
            //Oben
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                movementVertical = -1;
            }
            else
            {
                movementVertical = 0;
                moveUp = true;
                moveDown = true;
            }

            //Rechts
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Debug.Log("Rechts");
                movementHorizontal = 1;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
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
        }

        //Bewegung nach Unten
        if (moveDown)
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
                playerAnim.SetBool("right", true);
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed / 2f);
            }
            else
            {
                playerAnim.Play("Corgi_Idle");
                playerAnim.SetBool("right", false);

            }
        }

        //Bewegung nach Links
        if (moveLeft)
        {
            if (movementHorizontal == -1)
            {
                playerAnim.SetBool("left", true);
                transform.Translate(Vector3.right * Time.deltaTime * -horizontalSpeed);
            }
            else
            {
                playerAnim.SetBool("left", false);

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

                bulletAnim.Play("create_beam");
                audio.PlayOneShot(pew, 0.2f);
                //Erstelle an dieser Position einen Pew Pew
                gameObject.GetComponent<BulletManager>().InstantiateBullet(bulletLvl);
            } 
        }
        else
        {
            bulletAnim.Play("Start");
        }
    }
    void MaxHealth()
    {
        if(health <= 0)
        {
            lifes--;
            health = 5;
        }
        if(health >= 5)
        {
            health = 5;
        }
    }

    //Bei Berührung der Barrieren, bewegung deaktivieren für die jeweilige richtung
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

    //Bei Berührung mit einem Gegner bzw. Hinterniss, ziehe ein leben ab
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "BadGuy")
        {
            health--;
            StartCoroutine(TempInvisible());
            
        }
        if(col.tag == "BadGuyBullet")
        {
            health--;
            StartCoroutine(TempInvisible());

        }
    }

    //Kurzzeitige Unbesiegbarkeit 
    IEnumerator TempInvisible()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(ToggleSpriteRenderer());

        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

    }
    //Toggelt den Spriterenderer ein und aus
    IEnumerator ToggleSpriteRenderer()
    {
        while (gameObject.GetComponent<BoxCollider2D>().enabled == false)
        {
            yield return new WaitForSeconds(0.2f);
            if (gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
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
