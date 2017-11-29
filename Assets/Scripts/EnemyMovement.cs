using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    public Enemy enemy;
    public GameObject enemyObject;
    Transform target;
    int currentWaypoint;

    void Start()
    {
        
           currentWaypoint = 0;
        target = Waypoints.points[currentWaypoint];
    }
    
    void Update ()
    {
        //distance to waypoint
        Vector3 dir = target.position - transform.position;

        //move towards it
        transform.Translate(dir.normalized*enemy.speed*Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        
	}
    void GetNextWaypoint()
    {
        if(currentWaypoint >= Waypoints.points.Length - 1)
        {
            if (enemyObject != null)
            {
                //Debug.Log("Enemy walked to end");
                Destroy(enemyObject);
            }
            return;
        }
        currentWaypoint++;
        target = Waypoints.points[currentWaypoint];
    }
}
