using System;
using Vadim;
using UnityEngine;

public class Waypoints : Singleton<Waypoints>
{
    
    public event Action EventOnStopRunning;
    public event Action EventOnStartRunning;


    public Waypoint[] points;

    int nextWaypointIndex;
    private void Start()
    {
        points = new Waypoint[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i).GetComponent<Waypoint>();
        }
    }

    public void OnReachedTarget()
    {
        if (points[nextWaypointIndex] == points[points.Length-1])
        {
            Debug.Log("Yep");
            GameManager.Instance.Restart();
        }
        EventOnStopRunning?.Invoke();
    }
    public void ChangeWaypoint(int _wayPointIndex)
    {
        EventOnStartRunning?.Invoke();
        nextWaypointIndex = _wayPointIndex + 1;
        PlayerMovement.Instance.ChangePosition(points[nextWaypointIndex].transform.position);
    }
}
