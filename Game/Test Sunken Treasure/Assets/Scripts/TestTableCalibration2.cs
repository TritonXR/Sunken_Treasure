using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTableCalibration2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float calibratedHeight;
    public GameObject table;
    public GameObject buttons;
    void Start()
    {

        calibratedHeight = PlayerPrefs.GetFloat("Height");
        table.transform.localPosition = new Vector3(table.transform.localPosition.x, calibratedHeight, table.transform.localPosition.z);
        buttons.transform.localPosition = new Vector3(buttons.transform.localPosition.x, calibratedHeight + .7f, buttons.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
