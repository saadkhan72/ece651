
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{

    [SerializeField] public GameObject[] waypoints;
    //private int CurrentWayPoint = 0;
    //private bool direction = false;//true= ++, false=--

    [SerializeField] private float speed = 2f;
    //[SerializeField] private bool cycle = false;
    //private bool faceleft = true;
    public Vector3 velocity,lastpos;
    public int choose;
    void Start()
    {
        choose = Random.Range(0, waypoints.Length);
        lastpos = transform.position;
    }
    private void FixedUpdate()
    {
        //velocity = (transform.position - pos) / Time.deltaTime;
        velocity = (transform.position - lastpos) / Time.deltaTime;
        lastpos = transform.position;
        if (Vector2.Distance(waypoints[choose].transform.position, transform.position) < .1f)
        {
            choose = Random.Range(0, waypoints.Length);
            if (waypoints[choose].transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[choose].transform.position, Time.deltaTime * speed); //framerate independant 
    }
}