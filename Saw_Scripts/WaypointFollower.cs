using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int CurrentWayPoint = 0;
    private bool direction=false;//true= ++, false=--

    [SerializeField] private float speed = 2f;
    [SerializeField] private bool cycle = false;

    private void Update()
    {
        //Debug.Log(CurrentWayPoint);
        if (cycle)
        {
            if (Vector2.Distance(waypoints[CurrentWayPoint].transform.position, transform.position) < .1f)
            {
                
                if (CurrentWayPoint == waypoints.Length-1 || CurrentWayPoint <= 0)
                {
                    direction = !direction;//flip direction of indexing waypoint array
                }

                if (direction)
                {
                    CurrentWayPoint++;
                }
                else
                {
                    CurrentWayPoint--;
                }
            }
            
        } else
        {
            if (Vector2.Distance(waypoints[CurrentWayPoint].transform.position, transform.position) < .1f)
            {
                        
                        if (CurrentWayPoint >= waypoints.Length-1)
                        {
                            CurrentWayPoint = -1;
                        }
                        CurrentWayPoint++;
            }
        }
        



        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWayPoint].transform.position, Time.deltaTime * speed); //framerate independant 
    }
}
