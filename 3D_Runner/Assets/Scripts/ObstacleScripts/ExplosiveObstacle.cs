using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class ExplosiveObstacle : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int damage = 20;
    private GameObject w1, w2, w3, w4, w5, w6; //Widgets
    private Animator w1Anim, w2Anim, w3Anim,w4Anim, w5Anim, w6Anim; //Animation of widgets

    //Finding all widgets objects in UI
    private void Start()
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

    //Aply damage to player, show widgets (screen spots effect) and show explosion effects of objects
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
            gameObject.SetActive(false);

            if(explosionPrefab != null)
            {
                switch (explosionPrefab.name)
                {
                    case "GlassEffect":
                        w1Anim.Play("W1");
                        break;

                    case "Spaghetti  Effect":
                        w2Anim.Play("W2");
                        break;

                    case "PomodoroEffect":
                        w3Anim.Play("W3");
                        break;

                    case "IceCreamEffect":
                        w4Anim.Play("W4");
                        break;

                    case "Ravioli effect":
                        w5Anim.Play("W5");
                        break;

                    case "KnifeEffect":
                        w6Anim.Play("W6");
                        break;

                }
            }  
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        

    }

}
