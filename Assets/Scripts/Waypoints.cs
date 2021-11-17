using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    #region Singleton
    public static Waypoints instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    public Waypoint[] points;
    public PlayerMovement PlayerMovement;

    int nextWaypointIndex;
    private void Start()
    {
        points = new Waypoint[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i).GetComponent<Waypoint>();
        }
    }

    public bool IsLastWaypoint(int index)
    {
        if (index==points.Length-1)
        {
            return true;
        }
        return false;
    }
    public void ChangeWaypoint(int _wayPointIndex)
    {
        nextWaypointIndex = _wayPointIndex + 1;
        PlayerMovement.ChangePosition(points[nextWaypointIndex].transform.position,nextWaypointIndex);
    }
}
