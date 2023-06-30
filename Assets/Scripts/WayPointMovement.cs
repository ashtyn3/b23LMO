using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] WayPoints;
    [SerializeField]
    private float Speed = 2f;

    private int wpDest = 0;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(WayPoints[wpDest].transform.position, transform.position) < 0.1)
        {
            wpDest++;
            if (wpDest >= WayPoints.Length)
            {
                wpDest = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, WayPoints[wpDest].transform.position, Time.deltaTime * Speed);
    }
}
