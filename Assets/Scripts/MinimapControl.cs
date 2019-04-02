using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Minimap Script. This script attached to minimap camera. Camera used in orthographic projection mode
 */
 
public class MinimapControl : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

	}
}
