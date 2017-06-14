using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSpeed : MonoBehaviour {

    int speed = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Test");

        if (col.name == "BarriereEnd")
        {
            speed = 0;
            GameObject Camera = transform.parent.gameObject;
            Camera.GetComponent<CameraMovement>().speed = speed;
        }
        if (col.name == "BarriereSpeed20")
        {
            speed = 20;
            GameObject Camera = transform.parent.gameObject;
            Camera.GetComponent<CameraMovement>().speed = speed;
        }
        if (col.name == "BarriereSpeed40")
        {
            speed = 40;
            GameObject Camera = transform.parent.gameObject;
            Camera.GetComponent<CameraMovement>().speed = speed;
        }
        if (col.name == "BarriereSpeed60")
        {
            speed = 60;
            GameObject Camera = transform.parent.gameObject;
            Camera.GetComponent<CameraMovement>().speed = speed;
        }
        if (col.name == "BarriereSpeed80")
        {
            speed = 80;
            GameObject Camera = transform.parent.gameObject;
            Camera.GetComponent<CameraMovement>().speed = speed;
        }
        if (col.name == "BarriereSpeed100")
        {
            speed = 100;
            GameObject Camera = transform.parent.gameObject;
            Camera.GetComponent<CameraMovement>().speed = speed;
        }
    }

}
