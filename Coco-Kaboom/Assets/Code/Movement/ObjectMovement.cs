using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform startPoint; // The starting point of the platform
    public Transform endPoint;   // The ending point of the platform
    public float moveSpeed = 1.0f;

    private Vector3 currentPosition;
    public bool movingTowardsEnd = true;

    private void Start()
    {
        currentPosition = startPoint.position;
    }

    private void Update()
    {
        if (movingTowardsEnd)
        {
            currentPosition = Vector3.MoveTowards(currentPosition, endPoint.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            currentPosition = Vector3.MoveTowards(currentPosition, startPoint.position, moveSpeed * Time.deltaTime);
        }

        transform.position = currentPosition;

        // Check if the platform has reached the end point or starting point
        if (Vector3.Distance(currentPosition, endPoint.position) < 0.01f)
        {
            movingTowardsEnd = false;
        }
        else if (Vector3.Distance(currentPosition, startPoint.position) < 0.01f)
        {
            movingTowardsEnd = true;
        }
    }
}

