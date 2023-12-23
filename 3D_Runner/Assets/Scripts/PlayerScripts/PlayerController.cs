using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseController
{

    private Rigidbody myBody;
    public Transform bulletStartPoint;
    public GameObject bullrtPrefab;
    public ParticleSystem shootFX;
    private Animator shootSliderAnim;
    private Animator myAnim;
    [HideInInspector] public bool canShoot;


    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        shootSliderAnim = GameObject.Find("Fire bar").GetComponent<Animator>();
        myAnim = GameObject.Find("Fire bar").GetComponent<Animator>();
        canShoot = true;
    }

    // Call Moving and Rotation Player methods
    void FixedUpdate()
    {
        MovePlayer();
        ChangeRotation();
    }

    // Call Moving with Keyboard and Shoot Player methods
    private void Update()
    {
        ControlMovementWithKeyboard();
        Shoot();
    }

    void MovePlayer()
    {
        myBody.MovePosition(myBody.position + speed * Time.deltaTime);
    }

    void ControlMovementWithKeyboard()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight(); 
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {       
            MoveFast();
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {    
            MoveSlow();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveStraight();
            
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveStraight();   
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveNormal();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveNormal();
        }
    }

    void ChangeRotation()
    {
        if (speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, maxAngle, 0f),Time.deltaTime*rotationSpeed);
        }

        else if (speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }

        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }
    }

    public void ShootingControl()
    {
        if (Time.timeScale != 0)
        {
            if (canShoot)
            {
                GameObject bullet = Instantiate(bullrtPrefab, bulletStartPoint.position,
                Quaternion.identity);
                bullet.GetComponent<BulletScript>().Move(2000f);

                shootFX.Play();
                canShoot = false;
                shootSliderAnim.Play("Fill");
            }
        }
    }

    protected void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {      
            ShootingControl();
            canShoot = false;
        }
    }

}
