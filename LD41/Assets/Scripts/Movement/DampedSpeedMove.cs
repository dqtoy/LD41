using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampedSpeedMove : MonoBehaviour {
    public float startSpeed;
    public float endSpeed;
    public float transitionTime;
    public bool isFixedDirection;
    public Vector3 fixedDirection;

    private float speed;
    private float deltaSpeed;

	private void Start()
	{
        speed = startSpeed;
        deltaSpeed = (endSpeed - startSpeed) / transitionTime;
	}

	void Update()
    {
        UpdateSpeed();

        if (isFixedDirection)
        {
            transform.position += fixedDirection * Time.deltaTime * speed;
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    void UpdateSpeed()
    {
        speed += deltaSpeed * Time.deltaTime;
        if (speed < endSpeed)
            speed = endSpeed;

    }
}
