using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rotate360 : MonoBehaviour 
{
    float angle = 360.0f; // Degree per time unit
    float time = 300f; // Time unit in sec
    Vector3 axis = Vector3.up; // Rotation axis, here it the yaw axis

    private void Update()
    {
        transform.RotateAroundLocal(axis, 0.05f);
    }
}
