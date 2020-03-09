using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForward : MonoBehaviour
{
    public GameObject lever;
    public GameObject leverAnchor;
    public GameObject touchScreenPoint;
    public GameObject moveButton;
    public GameObject reverseButton;
    public GameObject leverToggleButton;
    public Vector3 orientation;
    //public Quaternion orientationGlobal;
    public Vector3 location;
    public Material green;
    public Material red;
    public Texture arrowUp;
    public Texture arrowDown;
    public Texture leverOn;
    public Texture leverOff;
    public float speed = 0.0f;
    public float maxSpeed = 2.5f;
    public float minSpeed = 0.0f;
    public float accel = 0.0f;
    public float minAccel = -0.1f;
    public float maxAccel = 1.0f;
    public bool moveSub = false;
    public int goBack = 1;
    //private int isMoving = 0;
    // Start is called before the first frame update
    void Start()
    {
        location = lever.transform.localPosition;
        lever.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //lever.transform.SetParent(this.transform);
        orientation = lever.transform.localRotation.eulerAngles;
        orientation.x = Mathf.Clamp(orientation.x, 315f, 360f);
        orientation.y = Mathf.Clamp(orientation.y, 0f, 0f);
        orientation.z = Mathf.Clamp(orientation.z, 0f, 0f);

        lever.transform.localRotation = Quaternion.Euler(orientation);
        //lever.transform.rotation = this.transform.rotation * orientation;

        /*if(orientation.x >= -0.2f)
        {
            accel += (orientation.x + 0.5f)/50.00f;
        }

        else if(orientation.x < -0.2f)
        {
            accel = minAccel;
        }*/
        if (lever.activeSelf)
        {
            if (lever.transform.localRotation.eulerAngles.x >= 345f)
            {
                accel += (orientation.x + 0.5f) / 50.00f;
            }

            else if (lever.transform.localRotation.eulerAngles.x < 345f)
            {
                accel = minAccel;
            }
        }
        else
        {
            if(moveSub == true)
            {
                accel += 0.5f / 50.00f;
            }

            else if(moveSub == false)
            {
                accel = minAccel;
            }
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
        this.transform.Translate(goBack * Vector3.forward * speed * Time.deltaTime);
        if (touchScreenPoint.transform.localPosition.y / 0.4386403f > 0.1f || touchScreenPoint.transform.localPosition.y / 0.4386403f < -0.1f)
        {
            this.transform.Rotate(Vector3.left * (touchScreenPoint.transform.localPosition.y / 0.4386403f) * Time.deltaTime * 5);
            //print(this.transform.rotation);
        }
        if (touchScreenPoint.transform.localPosition.x / 0.4386403f > 0.1f || touchScreenPoint.transform.localPosition.x / 0.4386403f < -0.1f)
        {
            this.transform.Rotate(Vector3.up * (touchScreenPoint.transform.localPosition.x / 0.4386403f) * Time.deltaTime * 5);
        }

    }

    public void MoveSub()
    {
        moveSub = !moveSub;
        if (moveSub)
        {
            moveButton.GetComponent<Renderer>().material = green;
        }
        else
        {
            moveButton.GetComponent<Renderer>().material = red;
        }
    }

    public void GoBackwards()
    {
        goBack = -goBack;
        if (goBack > 0)
        {
            reverseButton.GetComponent<Renderer>().material.SetTexture("_BaseMap", arrowUp);
        }
        else
        {
            reverseButton.GetComponent<Renderer>().material.SetTexture("_BaseMap", arrowDown);
        }
    }

    public void leverToggle()
    {
        lever.SetActive(!lever.activeSelf);
        if (lever.activeSelf)
        {
            leverToggleButton.GetComponent<Renderer>().material.SetTexture("_BaseMap", leverOn);
        }
        else
        {
            leverToggleButton.GetComponent<Renderer>().material.SetTexture("_BaseMap", leverOff);
        }
    }

    public void endGame()
    {
        Application.Quit();
    }

    public void resetPosition()
    {
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
    }

    private void LateUpdate()
    {
        lever.transform.position = leverAnchor.transform.position;
        //lever.transform.rotation = orientation * this.transform.rotation;
        //lever.transform.localPosition = location;
    }
}
