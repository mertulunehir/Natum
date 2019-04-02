using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/*
 * This Script controls characters movement, animation, attack.
 * In this script movement made with wasd keys. there is also another 
 * script for controlling character with joystick.
 */

public class CharacterControl : MonoBehaviour {

    private float speed = 3f;
    private Animator animControl;
    public Animator cameraAnim;

    public float health = 100f;
    private float damage = 10f;
    private bool attackControl = false;

    private bool attackBool = false;

    public static int killCount;

	// Use this for initialization
	void Start () {

        killCount = 0;

        animControl = GetComponent<Animator>();

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        Move();

        Attack();

        if(killCount == 10 || health<=0)
        {
            SceneManager.LoadScene("Menu");
        }

    }

    

    public void Attack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            AttackAnimation();
        }
        else if(attackBool)
        {
            AttackAnimation();
            attackBool = false;
        }
        else
        {
            attackControl = false;
        }

    }

    public void Move()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            animControl.SetBool("isRunning", true);
     
            transform.rotation = Quaternion.Euler(0, 315, 0);
            animControl.SetBool("isAttacking", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            animControl.SetBool("isRunning", true);
            
            transform.rotation = Quaternion.Euler(0, 45, 0);
            animControl.SetBool("isAttacking", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            animControl.SetBool("isRunning", true);
            
            transform.rotation = Quaternion.Euler(0, 135, 0);
            animControl.SetBool("isAttacking", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            animControl.SetBool("isRunning", true);
            
            transform.rotation = Quaternion.Euler(0, 225, 0);
            animControl.SetBool("isAttacking", false);
        }
        if (!Input.anyKey)
        {
            animControl.SetBool("isRunning", false);
            animControl.SetBool("isAttacking", false);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(attackControl==true || attackBool == true)
            {
                other.GetComponent<CubeControl>().health -= 10f;
                other.GetComponent<CubeControl>().animControl.SetBool("Attacked", true);

                attackControl = false;
                attackBool = false;
            }                     
            health -= 3*Time.deltaTime;
        }
    }

    public void MoveUp()
    {
        animControl.SetBool("isRunning", true);
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        animControl.SetBool("isAttacking", false);
    }

    public void MoveDown()
    {
        animControl.SetBool("isRunning", true);
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        animControl.SetBool("isAttacking", false);
    }

    public void MoveLeft()
    {
        animControl.SetBool("isRunning", true);
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 270, 0);
        animControl.SetBool("isAttacking", false);
    }

    public void MoveRight()
    {
        animControl.SetBool("isRunning", true);
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 90, 0);
        animControl.SetBool("isAttacking", false);
    }

    public void AttackAnimation()
    {
        animControl.SetBool("isAttacking", true);
        attackControl = true;
    }

    public void AttackButton()
    {
        attackBool = true;
    }

}
