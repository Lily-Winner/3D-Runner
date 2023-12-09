using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public GameObject bloodFXPrefab;
    private Rigidbody myBody;
    private float speed =1f;
    private bool isAlive;




    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        speed = Random.Range(3f, 9f);
        myBody.velocity = new Vector3(0f, 0f, -speed);
        isAlive = true;
    }

    
    void Update()
    {
        if (isAlive)
        {
            myBody.velocity = new Vector3(0f, 0f, -speed);
        }

        if (transform.position.y <-10f)
        {
            gameObject.SetActive(false);
        }
    }

    void Die()
    {
        isAlive = false;
        myBody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
        
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Instantiate(bloodFXPrefab, transform.position, Quaternion.identity);
            Invoke("DeactivateGameObject", 3f);
            gameplayController.instance.IncreaseScore();
            Die();
        }
    }

    public void PauseGame()
    {

    }
}
