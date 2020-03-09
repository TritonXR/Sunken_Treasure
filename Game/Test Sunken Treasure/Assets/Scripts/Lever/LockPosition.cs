using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPosition : MonoBehaviour
{
    private bool lockStatus;
    private Rigidbody rb;
    public bool isLocked {
        set {
            lockStatus = value;
            if (value) {
                rb.freezeRotation = false;
                rb.constraints = RigidbodyConstraints.FreezePosition;

            } else {
                rb.freezeRotation = true;
                rb.constraints = RigidbodyConstraints.None;
            }
        }
        get {
            return lockStatus;
        }
    }
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        isLocked = true;
    }

    // Update is called once per frame
    void Update() {

    }
}
