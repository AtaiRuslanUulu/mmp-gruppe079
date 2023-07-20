using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public Transform [] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    // Update is called once per frame
    void Update()
    {
        if (patrolDestination == 0) 
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            // check if destination reached
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f) 
            {
                // close to patrol point then turn to other point
                patrolDestination = 1;
            }
        } 

        // check other direction
        if (patrolDestination == 1) 
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            // check if destination reached for other point
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f) 
            {
                // send back to 0
                patrolDestination = 0;
            }
        }
    }
}
