using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForward : MonoBehaviour
{
    public GameObject lever;
    public GameObject leverAnchor;
    public GameObject touchScreenPoint;
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
        orientation.x = Mathf.Clamp(orientation.x, this.transform.rotation.x -0.375f, this.transform.rotation.x /*+ 0f*/);
        orientation.y = Mathf.Clamp(orientation.y, this.transform.rotation.y /*+ 0f*/, this.transform.rotation.y /*+ 0f*/);
        orientation.z = Mathf.Clamp(orientation.z, this.transform.rotation.z /*+ 0f*/, this.transform.rotation.z /*+ 0f*/);

        lever.transform.rotation = orientation;

        /*if(orientation.x >= -0.2f)
        {
            accel += (orientation.x + 0.5f)/50.00f;
        }

        else if(orientation.x < -0.2f)
        {
            accel = minAccel;
        }*/

        if (lever.transform.localRotation.x >= -0.2f)
        {
            accel += (orientation.x + 0.5f) / 50.00f;
        }

        else if (lever.transform.localRotation.x < -0.2f)
        {
            accel = minAccel;
        }

        if (accel >= maxAccel)
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
        if (touchScreenPoint.transform.localPosition.y / 0.4386403f > 0.1f || touchScreenPoint.transform.localPosition.y / 0.4386403f < -0.1f)
        {
            this.transform.Rotate(Vector3.right * (touchScreenPoint.transform.localPosition.x / 0.4386403f) * Time.deltaTime * 5);
        }
        if (touchScreenPoint.transform.localPosition.x / 0.4386403f > 0.1f || touchScreenPoint.transform.localPosition.x / 0.4386403f < -0.1f)
        {
            this.transform.Rotate(Vector3.down * (touchScreenPoint.transform.localPosition.y / 0.4386403f) * Time.deltaTime * 5);
        }

    }

    public void RotateForward()
    {
        this.transform.Rotate(Vector3.right * 5 /** Time.deltaTime*/);
    }

    private void LateUpdate()
    {
        lever.transform.position = leverAnchor.transform.position;
        //lever.transform.localPosition = location;
    }
}
