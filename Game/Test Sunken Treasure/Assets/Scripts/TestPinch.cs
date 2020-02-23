using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPinch : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var hand = GetComponent<OVRHand>();
        var bone = GetComponent<OVRSkeleton>();
        float indexFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb);
        float middleFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle);
        float ringFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
        //print(indexFingerPinchStrength);
    }


}
