using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] points;

    void Awake()
    {
        //ASSUMPTION: child waypoint objects are in order
        //Array of waypoints
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            //Add point for each child waypoint of waypoints
            points[i] = transform.GetChild(i);
        }
    }
}
