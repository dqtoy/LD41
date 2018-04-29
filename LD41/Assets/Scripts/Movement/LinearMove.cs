using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour {
    public float speed;
    public bool isFixedDirection;
    public Vector3 fixedDirection;

	void Update () {
        if (isFixedDirection)
        {
            transform.position += fixedDirection * Time.deltaTime * speed;
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
	}
}
