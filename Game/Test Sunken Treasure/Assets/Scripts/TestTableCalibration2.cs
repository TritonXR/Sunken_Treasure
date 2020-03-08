using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTableCalibration2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float calibratedHeight;
    public float calibratedDistance;
    public GameObject table;
    public GameObject buttons;
    public GameObject lever;
    public GameObject leverAnchor;
    void Start()
    {

        calibratedHeight = PlayerPrefs.GetFloat("Height");
        calibratedDistance = PlayerPrefs.GetFloat("Distance");
        table.transform.localPosition = new Vector3(table.transform.localPosition.x, calibratedHeight, calibratedDistance - 0.035f);
        buttons.transform.localPosition = new Vector3(buttons.transform.localPosition.x, calibratedHeight + 0.7f, calibratedDistance - 0.3f);
        lever.transform.localPosition = new Vector3(lever.transform.localPosition.x, calibratedHeight + 0.5f, calibratedDistance - 0.35f);
        leverAnchor.transform.localPosition = new Vector3(leverAnchor.transform.localPosition.x, calibratedHeight + 0.5f, calibratedDistance - 0.35f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
