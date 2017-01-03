using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    private Transform target;
    private int wavepointIndex = 0;

    public float speed = 10f;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        if (GameState.instance.IsInPlay())
        {
            //Assign Direction and move
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            //If are close to waypoint - we are at waypoint
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
        else if (GameState.instance.IsGameOver())
        {
            Destroy(gameObject);
        }
    }

    void GetNextWaypoint()
    {
        //End reached
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            GameState.instance.EndReached();
            PointsManager.instance.LostHealth();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
