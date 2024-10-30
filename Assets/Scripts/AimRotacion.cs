using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotacion : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    void Update()
    {
        Vector3 targetOrientation = _target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.green);

        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);
    }
}
