using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTableCalibration : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tableHeight;
    public GameObject tableDistance;
    public Vector3 tablePositionHeight;
    public Vector3 tablePositionDistance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tablePositionHeight = tableDistance.transform.position;
        tablePositionDistance = tableDistance.transform.position;
    }

    private void LateUpdate()
    {
        PlayerPrefs.SetFloat("Height", tablePositionHeight.y);
        PlayerPrefs.SetFloat("Distance", tablePositionDistance.z);
    }
}
