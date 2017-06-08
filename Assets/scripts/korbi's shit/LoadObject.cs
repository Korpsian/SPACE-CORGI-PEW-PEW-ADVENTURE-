using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObject : MonoBehaviour {

    public GameObject objTest = null;

	// Use this for initialization
	void Start () {
        Instantiate(objTest);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
