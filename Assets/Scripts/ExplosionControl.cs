using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This Scripts destroys the explosion game object after cube instantiated it. this script created for optimization issues.
 */ 

public class ExplosionControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destroy", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Destroy()
    {
        Destroy(gameObject);
    }
}
