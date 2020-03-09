using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    public LineRenderer lr;
    public GameObject controlPoint1;

    public GameObject targetItem;
    public GameObject itemSpot1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.rotation * Vector3.forward, out hit)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.transform.gameObject);
            if(hit.transform.gameObject.tag == "Target") {
                lr.enabled = true;
                lr.SetPosition(0, controlPoint1.transform.position);
                lr.SetPosition(1, hit.point);
            } else {
                lr.enabled = false;
            }
        } else {
            lr.enabled = false;
        }
        if (Input.GetKeyDown("q")) {
            FireGrapple();
        }
    }

    private void FireGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
            Instantiate(targetItem, itemSpot1.transform.position, Quaternion.identity);
            Destroy(hit.transform.gameObject);
        }
    }
}
