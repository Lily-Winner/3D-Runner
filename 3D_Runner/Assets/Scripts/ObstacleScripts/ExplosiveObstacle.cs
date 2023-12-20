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
    private GameObject w1;
    private Animator w1Anim;
    private bool canPlay;





    private void Awake()
    {
        w1 = GameObject.Find("W1");
        w1Anim = w1.GetComponent<Animator>();
  
    }



    private void Start()
    {
        

    }

    private void Update()
    {
        canPlay = true;
       
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

            //if (explosionPrefab.name == "Spaghetti  Effect")
            //{
            //    Widget1.Play("WSpagetti");
            //    canPlay1 = false;

            //}

        }
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        

    }


   

}
