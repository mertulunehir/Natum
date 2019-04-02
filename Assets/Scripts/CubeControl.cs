using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EZCameraShake;

/*
 * This Script controls cube movement, animation, navigation and 
 * destroy of cubes. Also in this script, camera shake is controlled.  
 */ 

public class CubeControl : MonoBehaviour {

    public GameObject target;
    public NavMeshAgent agent;

    public GameObject explosion;

    public Animator animControl;

    public float health=20f;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");

        animControl = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       

		if(health<=0f)
        {
            Invoke("Destroy", 0.5f);
        }
        agent.SetDestination(target.transform.position);
	}

    void Destroy()
    {
        CharacterControl.killCount++;
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
        CameraShaker.Instance.ShakeOnce(0.5f,1f,0.1f,1f);
    }
}
