using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMovement : MonoBehaviour
{
    public Transform [] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public Transform playerTransform; //keep track of players position
    public bool isChasing; //is enemy in chase mode
    public float chaseDistance; //how close to get that enemy chases

    // Update is called once per frame
    void Update()
    {
        if (isChasing) 
        {
            // make chase happen
            // not using Vector2 so that enemy can not in the air
            if (transform.position.x > playerTransform.transform.position.x) 
            {
               // enemy is on players right side - enemy moves to player so left
               transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (transform.position.x < playerTransform.transform.position.x) 
            {
               // enemy is on players left side - enemy moves to player so right
               transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        else
        {
            // check if player close enough to chase
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance) 
            {
                isChasing = true; // go to upper code part
            }

            if (patrolDestination == 0) 
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                // check if destination reached
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f) 
                {
                    // close to patrol point then turn to other point
                    //transform.localScale = new Vector3(1, 1, 1);
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
                    //transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                }
            }  
        }
    }

    private void OnDrawGizmos()
    {
        // draw circles
        Gizmos.DrawWireSphere(patrolPoints[0].position, 0.5f); 
        Gizmos.DrawWireSphere(patrolPoints[1].position, 0.5f);
        // draw patrol path
        Gizmos.DrawLine(patrolPoints[0].transform.position, patrolPoints[1].transform.position);
    }
}