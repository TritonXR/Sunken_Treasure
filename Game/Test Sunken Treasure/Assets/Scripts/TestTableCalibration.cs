using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTableCalibration : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject table;
    public Vector3 tablePosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tablePosition = table.transform.position;
    }

    private void LateUpdate()
    {
        PlayerPrefs.SetFloat("Height", tablePosition.y);
    }
}
