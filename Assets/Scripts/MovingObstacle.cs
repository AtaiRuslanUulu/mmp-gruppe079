using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;

    public GameObject Ways_1;
    public Transform[] wayPoints;
    int pointIndex;
    int pointCount;
    int direction = 1;

    private void Awake()
    {
        wayPoints = new Transform[Ways_1.transform.childCount];
        for (int i = 0; i < Ways_1.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = Ways_1.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if(transform.position == targetPos)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        if (pointIndex == pointCount - 1) // arrived last point
        {
            direction = -1;
        }

        if (pointIndex == 0) // arrived first point
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }
}
