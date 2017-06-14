using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSpeed : MonoBehaviour {

    public int speed = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Test");

        if (col.name == "BarriereEnd")
        {
            GameObject Camera = transform.parent.gameObject;
            Camera.GetComponent<CameraMovement>().speed = speed;
        }
    }

}
