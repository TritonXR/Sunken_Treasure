using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForward : MonoBehaviour
{
    public GameObject lever;
    public Quaternion orientation;
    public Vector3 location;
    public float speed = 0.0f;
    public float maxSpeed = 10.0f;
    public float minSpeed = 0.0f;
    public float accel = 0.0f;
    public float minAccel = -0.1f;
    public float maxAccel = 1.0f;
    //private int isMoving = 0;
    // Start is called before the first frame update
    void Start()
    {
        location = lever.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        orientation = lever.transform.rotation;
        orientation.x = Mathf.Clamp(orientation.x, -0.5f, 0f);
        orientation.y = Mathf.Clamp(orientation.y, 0f, 0f);
        orientation.z = Mathf.Clamp(orientation.z, 0f, 0f);

        lever.transform.rotation = orientation;

        if(orientation.x >= -0.2f)
        {
            accel += (orientation.x + 0.5f)/50.00f;
        }

        else if(orientation.x < -0.2f)
        {
            accel = minAccel;
        }

        if(accel >= maxAccel)
        {
            accel = maxAccel;
        }

        speed += accel;
        
        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        else if(speed < minSpeed)
        {
            speed = minSpeed;
        }
        //print(speed);
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        lever.transform.position = this.transform.position + location;
    }
}
