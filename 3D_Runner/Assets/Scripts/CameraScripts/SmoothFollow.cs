using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 6.3f;
    public float height = 3.5f;
    public float height_Dumping = 3.25f;
    public float rotation_Dumping = 0.27f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float wanted_Rotation_Angle = target.eulerAngles.y;
        float wanted_Height = target.position.y + height;

        float current_Rotaton_Angle = transform.eulerAngles.y;
        float current_Height = transform.position.y;

        current_Rotaton_Angle = Mathf.LerpAngle(current_Rotaton_Angle, wanted_Rotation_Angle,
            rotation_Dumping*Time.deltaTime);
        current_Height = Mathf.Lerp(current_Height, wanted_Height, height_Dumping * Time.deltaTime);

        Quaternion current_Rotaton = Quaternion.Euler(0f, current_Rotaton_Angle, 0f);

        transform.position = target.position;
        transform.position -= current_Rotaton * Vector3.forward * distance; // how far it from the plyer

        transform.position = new Vector3(transform.position.x, current_Height, transform.position.z);
    }
}
