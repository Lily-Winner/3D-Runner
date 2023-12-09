using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Rigidbody myBody;


    public void Move(float speed)
    {
        myBody.AddForce(transform.forward.normalized * speed);
        Invoke("Deactivate", 5f);

    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
        }
    }
}