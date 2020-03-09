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
    public GameObject map;
    public GameObject sphere;
    void Start()
    {

        calibratedHeight = PlayerPrefs.GetFloat("Height");
        calibratedDistance = PlayerPrefs.GetFloat("Distance");
        table.transform.localPosition = new Vector3(table.transform.localPosition.x, calibratedHeight, calibratedDistance - 0.035f);
        buttons.transform.localPosition = new Vector3(buttons.transform.localPosition.x, calibratedHeight + 0.7f, calibratedDistance - 0.3f);
        lever.transform.localPosition = new Vector3(lever.transform.localPosition.x, calibratedHeight + 0.5f, calibratedDistance - 0.5f);
        leverAnchor.transform.localPosition = new Vector3(leverAnchor.transform.localPosition.x, calibratedHeight + 0.5f, calibratedDistance - 0.5f);
        map.transform.localPosition = new Vector3(map.transform.localPosition.x, calibratedHeight + 0.7f, calibratedDistance - 0.5f);
        sphere.transform.localPosition = new Vector3(sphere.transform.localPosition.x, calibratedHeight + 0.7f, calibratedDistance - 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
