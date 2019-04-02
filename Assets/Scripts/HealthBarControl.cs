using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  Health bar controlled from here. this script reaches player's Character control script 
 *  and change the fill amount of a image due to player's health. 
 * 
 */ 

public class HealthBarControl : MonoBehaviour {

    private float maxHealth = 100f;
    Image healthBar;

    private float currentHealth;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>().health;

        healthBar.fillAmount = currentHealth / maxHealth;
	}
}
