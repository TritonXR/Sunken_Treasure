using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    public HingeJoint joint;

    private bool lockStatus;

    private Rigidbody rb;


    public bool isLocked {
        set {
            lockStatus = value;
            if(value) {
                rb.freezeRotation = false;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                gameObject.transform.localRotation = Quaternion.identity;
                
               
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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocked) {
            gameObject.transform.localRotation = Quaternion.identity;
            Debug.Log(GetComponent<HingeJoint>().angle);
        }
    }
}
