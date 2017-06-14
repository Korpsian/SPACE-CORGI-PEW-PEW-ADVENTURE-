using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public GameObject bullet;

    public void InstantiateBullet(int lvl)
    {
        Vector2 pos;

        switch (lvl)
        {
            case 1:
                pos = this.transform.GetChild(0).transform.position;
                Instantiate(bullet, pos, Quaternion.identity);
                break;
            case 2:
                //Finde den Standpunkt des Child Objektes und verwende ihn
                pos = this.transform.GetChild(0).transform.position;
                pos.y = pos.y - 1;
                Instantiate(bullet, pos, Quaternion.identity);
                pos.y = pos.y + 2;
                Instantiate(bullet, pos, Quaternion.identity);
                break;
            case 3:
                pos = this.transform.GetChild(0).transform.position;
                pos.y = pos.y - 2;
                Instantiate(bullet, pos, Quaternion.identity);
                pos.y = pos.y + 2;
                Instantiate(bullet, pos, Quaternion.identity);
                pos.y = pos.y + 2;
                Instantiate(bullet, pos, Quaternion.identity);
                break;
            default:
                pos = this.transform.GetChild(0).transform.position;
                Instantiate(bullet, pos, Quaternion.identity);
                break;
        }

    }

}
