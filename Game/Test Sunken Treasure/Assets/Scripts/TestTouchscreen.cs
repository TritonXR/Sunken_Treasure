using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouchscreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slider;
    public Vector3 positionBoundaries;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        positionBoundaries = slider.transform.localPosition;
        positionBoundaries.x = Mathf.Clamp(positionBoundaries.x, -0.4386403f, 0.4386403f);
        positionBoundaries.y = Mathf.Clamp(positionBoundaries.y, -0.4386403f, 0.4386403f);
        slider.transform.localPosition = positionBoundaries;
    }

    private void OnCollisionStay(Collision collision)
    {
        slider.transform.localPosition = new Vector3(/*-slider.transform.position.x +*/ (collision.GetContact(0).point.x - this.transform.position.x) / 0.2193545f, 
                                                     /*-slider.transform.position.y +*/ (collision.GetContact(0).point.y - this.transform.position.y) / 0.171671f, 
                                                     slider.transform.localPosition.z);
    }
}
