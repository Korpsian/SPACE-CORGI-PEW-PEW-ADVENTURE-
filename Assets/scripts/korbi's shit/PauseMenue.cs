using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenue : MonoBehaviour {

    bool paused = false;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Escape"))
        {
            Debug.Log("Escape gedrückt");
            TogglePause();
        }
	}

    void TogglePause()
    {
        if (paused)
        {
            GameObject.Find("InGameUI").GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Find("InGamePauseMenu").GetComponent<CanvasGroup>().alpha = 0f;
            Time.timeScale = 1f;
            paused = false;
        }
        else
        {
            GameObject.Find("InGameUI").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("InGamePauseMenu").GetComponent<CanvasGroup>().alpha = 1f;
            Time.timeScale = 0f;
            paused = true;
        }
    }
}
