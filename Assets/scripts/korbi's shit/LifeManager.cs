using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

    public GameObject hundeKekse;
    public GameObject hundeKekseHallow;
    public GameObject gridSystem;
    public GameObject leftLifeObj;
    public GameObject thePlayer;

    int leftLifes;
    int leftHealth;

	// Use this for initialization
	void Start () {
        gridSystem = GameObject.Find("HundekeksGridSystem");
        leftLifeObj = GameObject.Find("LeftLife");
        thePlayer = this.gameObject;

        leftLifes = thePlayer.GetComponent<PlayerScript>().lifes;
        leftHealth = thePlayer.GetComponent<PlayerScript>().health;

        UpdHealth();
        UpdLifes();

    }
	
	// Update is called once per frame
	void Update () {
        var player = thePlayer.GetComponent<PlayerScript>();

        if(player.health != leftHealth)
        {
            leftHealth = player.health;
            UpdHealth();
        }

        if(player.lifes != leftLifes)
        {
            leftLifes = player.lifes;
            UpdLifes();
        }

	}

    void UpdHealth()
    {
        //Zählen der Hundekuchen Objekte
        int childCount = gridSystem.transform.childCount;
        //Wenn mehr als 0 Child Objekte da sind, lösche sie
        if(childCount > 0)
        {
            for(int i = 0; i < childCount; i++)
            {
                GameObject temp = gridSystem.transform.GetChild(i).gameObject;
                Destroy(temp);
            }
        }

        //Checken der Health des Spielers um dementsprechende HP anzuzeigen
        for(int i = 0; i < leftHealth; i++)
        {
            Instantiate(hundeKekse);
            GameObject temp = GameObject.Find("Hundekeks(Clone)");
            temp.name = "Hundekeks" + i;
            temp.transform.SetParent(gridSystem.transform);
        }


        for(int i = leftHealth; i < 5; i++)
        {
                Instantiate(hundeKekseHallow);
                GameObject temp = GameObject.Find("Hundekeks_hollow(Clone)");
                temp.name = "Hundekeks" + i + 1;
                temp.transform.SetParent(gridSystem.transform);
        }
    }

    void UpdLifes()
    {
       Text temp = leftLifeObj.GetComponent<Text>();
       if(leftLifes >= 10)
        {
            temp.text = leftLifes.ToString();
        }
        else
        {
            temp.text = "0" + leftLifes;
        }
    }
}
