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
            gameObject.GetComponent<EnemyShoot>().shootSpeed = 3;
            gameObject.GetComponent<UpDown>().s = 15;
        } else if(bosshp < 25)
        {
            GameObject[] test = GameObject.FindGameObjectsWithTag("BadGuyBullet");
            foreach (GameObject t in test)
            {
                Destroy(t);
            }


            gameObject.GetComponent<EnemyShoot>().shootSpeed = 5;
            gameObject.GetComponent<UpDown>().s = 25;
        }
    }
}
