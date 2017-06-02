using System.Collections;
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
            if (boo)
            {
                Debug.Log("shooting");
                StartCoroutine(Reloading(0.2f));
                Vector2 thisOne = this.transform.position;
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
