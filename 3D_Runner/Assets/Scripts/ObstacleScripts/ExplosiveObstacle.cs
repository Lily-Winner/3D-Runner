using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ExplosiveObstacle : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int damage = 20;
    private GameObject w1, w2, w3, w4, w5, w6;
    private Animator w1Anim, w2Anim, w3Anim,w4Anim, w5Anim, w6Anim;
    private bool canPlay, canPlay2;





    private void Awake()
    {
        w1 = GameObject.Find("W1");
        w1Anim = w1.GetComponent<Animator>();

        w2 = GameObject.Find("W2");
        w2Anim = w2.GetComponent<Animator>();

        w3 = GameObject.Find("W3");
        w3Anim = w3.GetComponent<Animator>();

        w4 = GameObject.Find("W4");
        w4Anim = w4.GetComponent<Animator>();

        w5 = GameObject.Find("W5");
        w5Anim = w5.GetComponent<Animator>();

        w6 = GameObject.Find("W6");
        w6Anim = w6.GetComponent<Animator>();

    }



    private void Start()
    {
        

    }

    private void Update()
    {
        canPlay = true;
        canPlay2 = true;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
            gameObject.SetActive(false);


            if (explosionPrefab.name == "GlassEffect")
            {
                w1Anim.Play("W1");
                canPlay = false;
            }

            if(explosionPrefab.name == "Spaghetti  Effect")
            {
                w2Anim.Play("W2");
                canPlay2 = false;
            }

            if (explosionPrefab.name == "PomodoroEffect")
            {
                w3Anim.Play("W3");
                canPlay2 = false;
            }

            if (explosionPrefab.name == "IceCreamEffect")
            {
                w4Anim.Play("W4");
                canPlay2 = false;
            }

            if (explosionPrefab.name == "Ravioli effect")
            {
                w5Anim.Play("W5");
                canPlay2 = false;
            }

            if (explosionPrefab.name == "KnifeEffect")
            {
                w6Anim.Play("W6");
                canPlay2 = false;
            }


        }
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        

    }


   

}
