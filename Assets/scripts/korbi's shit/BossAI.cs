using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var bosshp = gameObject.GetComponent<EnemyLifeManager>().hitPoints;

        if (bosshp < 150)
        {
            gameObject.GetComponent<EnemyShoot>().shootSpeed = 4;
            gameObject.GetComponent<UpDown>().s = 10;

        }


        if (bosshp < 100)
        {
            gameObject.GetComponent<EnemyShoot>().shootSpeed = 6;
            gameObject.GetComponent<UpDown>().s = 15;

        }

        if (bosshp < 50)
        {
            gameObject.GetComponent<EnemyShoot>().shootSpeed = 8;
            gameObject.GetComponent<UpDown>().s = 20;
        } else if(bosshp < 25)
        {
            gameObject.GetComponent<EnemyShoot>().shootSpeed = 10;
            gameObject.GetComponent<UpDown>().s = 30;
        }
    }
}
