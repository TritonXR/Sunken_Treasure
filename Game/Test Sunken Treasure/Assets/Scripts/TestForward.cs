using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForward : MonoBehaviour
{
    public GameObject lever;
    public Quaternion orientation;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orientation = lever.transform.rotation;
        orientation.x = Mathf.Clamp(orientation.x, -0.5f, 0.5f);
        lever.transform.rotation = orientation;
        this.transform.position += Vector3.forward * speed * orientation.x;
    }
}
