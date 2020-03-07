using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private float rotationX;
    private float rotationY;

    public static float SPEED_MULTIPLIER = 0.1F;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        float horiz = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        float mvmtHorizontal = Input.GetAxis("Horizontal");
        float mvmtVertical = Input.GetAxis("Vertical");

        if (horiz != 0) {
            RotateHoriz(horiz);
        }
        if (vertical != 0) {
            RotateVertical(vertical);
        }
        if(mvmtVertical != 0) {
            MoveVertical(mvmtVertical);
        }
        if (mvmtHorizontal != 0) {
            MoveHorizontal(mvmtHorizontal);
        }

    }

    private void MoveHorizontal(float movement) {
        Vector3 lookRotation = gameObject.transform.localRotation * Vector3.forward;
        Vector3 lookRotationXZ = new Vector3(lookRotation.x, 0, lookRotation.z);
        Vector3 rightXZ = Vector3.Cross(Vector3.up, lookRotationXZ).normalized;
        gameObject.transform.localPosition += rightXZ * movement * SPEED_MULTIPLIER;
        Vector3 pos = gameObject.transform.localPosition;
        gameObject.transform.localPosition = new Vector3(Mathf.Clamp(pos.x, -1f, 1f), pos.y, Mathf.Clamp(pos.z, -1f, 1f));
    }

    private void MoveVertical(float movement) {
        Vector3 lookRotation = gameObject.transform.localRotation * Vector3.forward;
        Vector3 lookRotationXZ = new Vector3(lookRotation.x, 0, lookRotation.z).normalized;
        Debug.Log(lookRotationXZ);
        gameObject.transform.localPosition += lookRotationXZ * movement * SPEED_MULTIPLIER;
        Vector3 pos = gameObject.transform.localPosition;
        gameObject.transform.localPosition = new Vector3(Mathf.Clamp(pos.x, -1f, 1f), pos.y, Mathf.Clamp(pos.z, -1f, 1f));
    }

    public void RecomputeRotation() {
        Quaternion parentRotation = gameObject.GetComponentInParent<Rigidbody>().rotation;
        Quaternion qRotateX = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion qRotateY = Quaternion.AngleAxis(rotationY, -Vector3.right);
        transform.localRotation = qRotateX * qRotateY;
    }

    public void RotateHoriz(float val) {
        rotationX = ClampAngle(val + rotationX, -360, 360);
        RecomputeRotation();
    }

    public void RotateVertical(float val) {
        rotationY = ClampAngle(val + rotationY, -60, 60);
        RecomputeRotation();
    }

    public static float ClampAngle(float angle, float min, float max) {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
