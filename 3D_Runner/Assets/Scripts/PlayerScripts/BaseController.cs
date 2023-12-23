using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 speed;
    public float x_speed=10f, z_Speed=15f;
    private float accelerated, deccelerated;
    protected float rotationSpeed = 10f;
    protected float maxAngle = 10f;
    private AudioSource soundManager;
    private Animator anim;
    private Collider myCollider;
    private int scoreCounter;

    void Awake()
    {
        speed = new Vector3(0f, 0f, z_Speed);
        soundManager = GetComponent<AudioSource>();
        anim= GameObject.Find("Player").GetComponent<Animator>();
        accelerated = z_Speed * 1.5f;
        deccelerated = z_Speed / 1.5f;
        myCollider = GetComponent<Collider>();  
    }

    //Turns on the score counter for Speed Methods
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "zombie")
        {
            scoreCounter++;   
        }
    }

    // Moving Methods (Speed dependent)

    protected void MoveLeft()
    {
        speed = new Vector3(-x_speed / 2f, 0f, speed.z);
        anim.Play("Right");
    }

    protected void MoveRight()
    {
        speed = new Vector3(x_speed / 2f, 0f, speed.z);
        anim.Play("Left");
    }


    // Moving Methods (Speed dependent & Speed affected depending on the points count)

    protected void MoveStraight()  // *In this method the speed icon changes.
    {
        speed = new Vector3(0f, 0f, speed.z);

        if (scoreCounter >= 20)
        {
            speed = new Vector3(0f, 0f, z_Speed + 5);
            
            GameObject.Find("Sc2").transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
            GameObject.Find("Sc1").transform.localScale = new Vector3(0f, 0f, 0f);
        }
            
        
        if (scoreCounter >= 50)
        {
            speed = new Vector3(0f, 0f, z_Speed + 10);
            GameObject.Find("Sc3").transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
            GameObject.Find("Sc2").transform.localScale = new Vector3(0f, 0f, 0f);
        }

        if (scoreCounter >= 100)
        {
            speed = new Vector3(0f, 0f, z_Speed + 15);
            GameObject.Find("Sc4").transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
            GameObject.Find("Sc3").transform.localScale = new Vector3(0f, 0f, 0f);
        }

        anim.Play("Idle");
        
    }

    protected void MoveNormal()
    {
        speed = new Vector3(speed.x, 0f, z_Speed);

        if (scoreCounter >= 20)
            speed = new Vector3(speed.x, 0f, z_Speed+5);
        if (scoreCounter >= 50)
            speed = new Vector3(speed.x, 0f, z_Speed + 10);
        if (scoreCounter >= 100)
            speed = new Vector3(speed.x, 0f, z_Speed + 15);
        anim.Play("Idle");
        
    }

    protected void MoveSlow()
    {
        speed = new Vector3(speed.x, 0f, deccelerated);

        if (scoreCounter >= 20)
            speed = new Vector3(speed.x, 0f, deccelerated+5);
        if (scoreCounter >= 50)
            speed = new Vector3(speed.x, 0f, deccelerated + 10);
        if (scoreCounter >= 100)
            speed = new Vector3(speed.x, 0f, deccelerated + 15);
        anim.Play("Idle");
    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0f, accelerated);

        if (scoreCounter >= 20)
            speed = new Vector3(speed.x, 0f, accelerated+5);
        if (scoreCounter >= 50)
            speed = new Vector3(speed.x, 0f, accelerated + 10);
        if (scoreCounter >= 100)
            speed = new Vector3(speed.x, 0f, accelerated + 15);
        anim.Play("Idle");
    }
    
}
