using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotater : MonoBehaviour
{
    public GameObject controlPoint;
    private float value;
    // Update is called once per frame
    void Update()
    {
        Transform parentTransform = gameObject.transform.parent.transform;
        Vector3 forward = parentTransform.forward;
        Vector3 up = parentTransform.up;
        Vector3 right = parentTransform.right;
        Vector3 controlPointVector = controlPoint.transform.position - gameObject.transform.position;

        Vector3 temporaryVector = Vector3.Cross(controlPointVector, right);
        Vector3 finalVector = Vector3.Cross(right, temporaryVector);
        Quaternion rotation = Quaternion.LookRotation(finalVector, Vector3.up);
        gameObject.transform.rotation = rotation;
        float dot = Vector3.Dot(finalVector, up);
        dot /= (finalVector.magnitude * up.magnitude);
        float angle = Mathf.Acos(dot);
        float signed = angle * (Vector3.Dot(finalVector, forward) > 0 ? 1f : -1f);
        float clamped = Mathf.Clamp(signed, -60f * Mathf.Deg2Rad, 60f * Mathf.Deg2Rad);
        value = clamped * Mathf.Rad2Deg;

        Vector3 trueLookVector = new Vector3(0, Mathf.Cos(clamped), Mathf.Sin(clamped));
        Quaternion trueLookRotation = Quaternion.LookRotation(trueLookVector, Vector3.up);
        gameObject.transform.rotation = trueLookRotation;


    }

    void OnDrawGizmos() {
        Transform parentTransform = gameObject.transform.parent.transform;
        Vector3 forward = parentTransform.forward;
        Vector3 up = parentTransform.up;
        Vector3 right = parentTransform.right;
        Vector3 controlPointVector = controlPoint.transform.position - gameObject.transform.position;

        Vector3 temporaryVector = Vector3.Cross(controlPointVector, right);
        Vector3 finalVector = Vector3.Cross(right, temporaryVector);
        Quaternion rotation = Quaternion.LookRotation(finalVector, Vector3.up);
        gameObject.transform.rotation = rotation;
        float dot = Vector3.Dot(finalVector, up);
        dot /= (finalVector.magnitude * up.magnitude);
        float angle = Mathf.Acos(dot);
        float signed = angle* (Vector3.Dot(finalVector, forward) > 0 ? 1f : -1f);
        float clamped = Mathf.Clamp(signed, -60f*Mathf.Deg2Rad, 60f*Mathf.Deg2Rad);


        Vector3 trueLookVector = new Vector3(0, Mathf.Cos(clamped), Mathf.Sin(clamped));

        Gizmos.color = Color.white;
        Gizmos.DrawRay(gameObject.transform.position, controlPointVector.normalized * 4);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gameObject.transform.position, up.normalized * 4);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(gameObject.transform.position, right.normalized * 4);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(gameObject.transform.position, finalVector.normalized * 4);
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(gameObject.transform.position, trueLookVector.normalized* 4);
    }
}
