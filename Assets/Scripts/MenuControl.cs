using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  Main Menu Script. Button methods are in this script.
 * 
 */ 

public class MenuControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
