using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDistanceCalibration : MonoBehaviour
{
    public GameObject tableHeight;
    public GameObject tableDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "calibrator")
        {
            tableHeight.SetActive(false);
            tableDistance.transform.position = tableHeight.transform.position;
            tableDistance.SetActive(true);
        }
    }
}
