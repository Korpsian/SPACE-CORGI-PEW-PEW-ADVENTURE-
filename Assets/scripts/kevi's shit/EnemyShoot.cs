using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    bool reloaded = true;
    public float shootSpeed = 0;

	// Update is called once per frame
	void FixedUpdate () {
        Shoot();
	}
    void Shoot()
    {
        if (reloaded)
        {
            StartCoroutine(Reloading(shootSpeed));
            gameObject.GetComponent<EnemyBulletManager>().InstantiateBullet();
        }

    }
    IEnumerator Reloading(float time)
    {
        reloaded = false;
        time = Random.Range(1f, 4f);
        yield return new WaitForSeconds(time);
        reloaded = true;
    }
}
