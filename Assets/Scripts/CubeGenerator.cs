using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script generates cubes in the game area randomly with the random x and y positions.
 * 
 * 
 */ 

public class CubeGenerator : MonoBehaviour {
    /*
     * z = 36 ile 166
     * x = 41 ile 160
     *
     */



    public GameObject cube;
    private float randX;
    private float randZ;

	// Use this for initialization
	void Start () {
		for(int i=0;i<10;i++)
        {
            randX = Random.Range(41f, 160f);
            randZ = Random.Range(36f, 166f);
            Instantiate(cube, new Vector3(randX,0.85f,randZ),Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
