using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform startPoint; // The starting point of the platform
    public Transform endPoint;   // The ending point of the platform
    private float moveSpeed = 0.1f;
    public Rigidbody2D rb;

    //private Vector3 currentPosition;
    public bool movingTowardsEnd = true;
    //private int targetIndex;

    private void Start()
    {
        gameObject.transform.position = startPoint.position;
        //targetIndex = 1;
    }

    private void FixedUpdate()
    {
        if (movingTowardsEnd)
        {
            rb.position += new Vector2(moveSpeed, 0.0f);
            //currentPosition = Vector3.MoveTowards(currentPosition, endPoint.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.position -= new Vector2(moveSpeed, 0.0f);
            //currentPosition = Vector3.MoveTowards(currentPosition, startPoint.position, moveSpeed * Time.deltaTime);
        }
        //Debug.Log(Vector3.Distance(rb.position, endPoint.position));
        //transform.position = currentPosition;

        // Check if the platform has reached the end point or starting point
        if (Vector3.Distance(rb.position, endPoint.position) < 0.4f)
        {
            movingTowardsEnd = false;
            //Debug.Log("ya");
        }
        else if (Vector3.Distance(rb.position, startPoint.position) < 0.4f)
        {
            movingTowardsEnd = true;
        }
        
    }
}

