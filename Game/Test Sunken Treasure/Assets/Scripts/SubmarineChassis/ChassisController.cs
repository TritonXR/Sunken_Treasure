using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChassisController : MonoBehaviour
{
    Rigidbody rb;
    Quaternion originalRotation;

    public static float SPEED = 1F;

    public HingeJoint verticalLever;

    private float rotationX;
    private float rotationY;

    public bool isResettingY = false;
    private float angularVelocity = 180 * Mathf.Deg2Rad;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        originalRotation = rb.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(verticalLever.angle);
        float horiz = Input.GetAxis("ArrowHoriz");
        float vertical = Input.GetAxis("ArrowVertical");
        //vertical = verticalLever.angle / -60f;
        
        //Debug.Log(rotationY);
        bool throttle = Input.GetKey("space");

        if(Input.GetKey("e")) {
            isResettingY = true;
        }

        if (!isResettingY) {
            if (rb.velocity.magnitude > 0) {
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.8F);
            }
            if (horiz != 0) {
                RotateHoriz(horiz);
            }
            if (vertical != 0) {
                RotateVertical(vertical);
            }

            if (throttle) {
                ForwardThrottle();
            }
        } else {
            float potentialChange = Time.deltaTime * angularVelocity * (rotationY > 0 ? -1f : 1f);
            if(Mathf.Abs(rotationY) > Mathf.Abs(potentialChange)) {
                RotateVertical(potentialChange);
            } else {
                RotateVertical(-rotationY);
                isResettingY = false;
            }
        }


    }

    public void RecomputeRotation()
    {
        Quaternion qRotateX = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion qRotateY = Quaternion.AngleAxis(rotationY, -Vector3.right);
        rb.rotation = originalRotation * qRotateX * qRotateY;
    }

    public void ForwardThrottle()
    {
        rb.velocity = rb.rotation * Vector3.forward * SPEED;
    }

    public void RotateHoriz(float val)
    {
        rotationX = ClampAngle(val + rotationX, -360, 360);
        RecomputeRotation();
    }

    public void RotateVertical(float val)
    {
        rotationY = ClampAngle(val + rotationY, -60, 60);
        RecomputeRotation();
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
