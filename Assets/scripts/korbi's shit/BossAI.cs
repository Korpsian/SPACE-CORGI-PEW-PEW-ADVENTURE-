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

        if(bosshp < 50)
        {
            gameObject.GetComponent<EnemyShoot>().shootSpeed = 2;
            gameObject.GetComponent<UpDown>().s = 10;
        } else if(bosshp < 25)
        {
            gameObject.GetComponent<EnemyShoot>().shootSpeed = 3;
            gameObject.GetComponent<UpDown>().s = 15;

        }
    }
}
